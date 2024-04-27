using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Manage.Constraints
{
    public class LanguageConstraint : IRouteConstraint
    {
        private readonly IServiceProvider serviceProvider;

        public LanguageConstraint(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var languages = _unitOfWork.Languages.GetAllEnabledNames().Result;
                return languages.Contains(values[routeKey]);
            }
        }
    }
}
