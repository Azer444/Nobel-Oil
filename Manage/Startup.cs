using Core;
using Core.Models;
using Core.RouteConstraints;
using Data;
using Data.Contexts;
using Manage.Constraints;
using Manage.Tools.EmailHandler.Abstract;
using Manage.Tools.EmailHandler.Configuration;
using Manage.Tools.EmailHandler.Implementation.SMTP;
using Manage.Tools.FileHandler.Abstraction;
using Manage.Tools.FileHandler.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;

namespace Manage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Disable EndpointRouting
            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
                option.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });


            #region Context


            var connectionString = Configuration.GetConnectionString(Environment.GetEnvironmentVariable("CONNECTION_STRING_NAME") ?? "BloggingDatabase");

            //Context
            services.AddDbContext<NobelContext>(option => option.UseSqlServer(connectionString, x => x.MigrationsAssembly("Data")));

            //Environment.GetEnvironmentVariable("CONNECTION_STRING_NAME")
            //Production


            #endregion
            #region Localization and Globalization

            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("az"),
            };

            var options = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
            };

            options.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider() { Options = options });

            services.AddSingleton(options);

            #endregion


            #region Routing configurations

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.ConstraintMap.Add("flatpageurl", typeof(FlatPageConstraint));
                options.ConstraintMap.Add("dynamicpageurl", typeof(DynamicPageConstraint));
            });

            #endregion

            //Constraints
            services.Configure<RouteOptions>(options => options.ConstraintMap.Add("languages", typeof(LanguageConstraint)));
            //

            //unitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //

            //inner services
            services.AddTransient<IFileService, FileService>();

            //Policy and Role changes will be effected immediately
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.Zero;
            });

            //email
            var smtpConfig = Configuration.GetSection("SMTPConfiguration").Get<SMTPConfiguration>();
            services.AddSingleton(smtpConfig);
            services.AddTransient<IEmailService, EmailService>();

            //Identity
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
            })
              .AddRoles<Role>()
              .AddEntityFrameworkStores<NobelContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/admin/account/login";
                //options.AccessDeniedPath = "/admin/account/login";
                options.ExpireTimeSpan = TimeSpan.FromHours(24);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            #region Localization and globalization

            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            #endregion

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=home}/{action=index}/{id?}"
                );

                routes.MapRoute(
                   name: "default",
                   template: "{culture}/{controller}/{action=index}/{id?}"
                );
            });
        }
    }
}
