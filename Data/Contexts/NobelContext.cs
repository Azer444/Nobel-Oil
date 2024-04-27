using Core.Models;
using Core.Models.Abstraction;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class NobelContext : IdentityDbContext<User, Role, string>
    {
        public NobelContext(DbContextOptions<NobelContext> options)
            : base(options)
        {

        }

        public DbSet<News> News { get; set; }
        public DbSet<AboutComponent> AboutComponent { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<PageMainPhoto> PageMainPhotos { get; set; }
        public DbSet<VMVComponent> VMVComponent { get; set; }
        public DbSet<VMVComponentPhoto> VMVComponentPhotos { get; set; }
        public DbSet<HistoryComponent> HistoryComponents { get; set; }
        public DbSet<NobelHeritage> NobelHeritages { get; set; }
        public DbSet<NobelHeritagePhoto> NobelHeritagePhotos { get; set; }
        public DbSet<CorporateGovernanceComponent> CorporateGovernanceComponent { get; set; }
        public DbSet<ExecutiveManagementComponent> ExecutiveManagementComponent { get; set; }
        public DbSet<BoardDirectorComponent> BoardDirectorComponent { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<OurBusiness> OurBusinesses { get; set; }
        public DbSet<OurProjectComponent> OurProjectComponent { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SustainableDevelopment> SustainableDevelopment { get; set; }
        public DbSet<SustainabilityReport> SustainabilityReport { get; set; }
        public DbSet<MainSustainabilityReport> MainSustainabilityReport { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<SafetyComponent> SafetyComponent { get; set; }
        public DbSet<SafetySubComponent> SafetySubComponents { get; set; }
        public DbSet<SafetySubComponentPhoto> SafetySubComponentPhotos { get; set; }
        public DbSet<EnvironmentComponent> EnvironmentComponent { get; set; }
        public DbSet<EnvironmentSubComponent> EnvironmentSubComponents { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<HumanResourceComponent> HumanResourceComponent { get; set; }
        public DbSet<HumanResourceComponentPhoto> HumanResourceComponentPhotos { get; set; }
        public DbSet<OurHistoryComponent> OurHistoryComponent { get; set; }
        public DbSet<CommunityComponent> CommunityComponent { get; set; }
        public DbSet<CommunityComponentPhoto> CommunityComponentPhotos { get; set; }
        public DbSet<EthicsComplianceComponent> EthicsComplianceComponent { get; set; }
        public DbSet<EthicsComplianceSubComponent> EthicsComplianceSubComponents { get; set; }
        public DbSet<EthicsComplianceSubComponentPdf> EthicsComplianceSubComponentPdfs { get; set; }
        public DbSet<CareerComponent> CareerComponents { get; set; }
        public DbSet<CareerTipComponent> CareerTipComponents { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<LegalNoticeComponent> LegalNoticeComponent { get; set; }
        public DbSet<CompanyService> CompanyServices { get; set; }
        public DbSet<SustainableGoal> SustainableGoals { get; set; }
        public DbSet<NavTitleComponent> NavTitleComponents { get; set; }
        public DbSet<NavComponent> NavComponents { get; set; }
        public DbSet<NavSubComponent> NavSubComponents { get; set; }
        public DbSet<EthicsAndCompilanceApply> EthicsAndCompilanceApplies { get; set; }
        public DbSet<MediaComponent> MediaComponents { get; set; }
        public DbSet<ImageGalleryComponent> ImageGalleryComponents { get; set; }
        public DbSet<ImageGalleryComponentPhoto> ImageGalleryComponentPhotos { get; set; }
        public DbSet<VideoGalleryComponent> VideoGalleryComponents { get; set; }
        public DbSet<PublicationReport> PublicationReports { get; set; }
        public DbSet<PublicationReportPdf> PublicationReportPdfs { get; set; }
        public DbSet<LifeAtNobelEnergyPdf> LifeAtNobelEnergyPdfs { get; set; }
        public DbSet<LifeAtNobelEnergy> LifeAtNobelEnergies { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<SiteConfig> SiteConfig { get; set; }
        public DbSet<HomeVideoComponent> HomeVideoComponent { get; set; }
        public DbSet<LanguageResource> LanguageResources { get; set; }
        public DbSet<PageTabComponent> PageTabComponents { get; set; }
        public DbSet<VacancyApply> VacancyApplies { get; set; }
        public DbSet<VacancyApplyFile> VacancyApplyFiles { get; set; }
        public DbSet<OurStrategyComponent> OurStrategyComponents { get; set; }
        public DbSet<KeyAreaComponent> KeyAreaComponents { get; set; }
        public DbSet<Flatpage> Flatpages { get; set; }
        public DbSet<DynamicPage> DynamicPages { get; set; }
        public DbSet<DynamicPageContent> DynamicPageContents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedValues(builder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        public void SeedValues(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(new Role { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Manager", NormalizedName = "MANAGER" });
            builder.Entity<Role>().HasData(new Role { Id = "3d6z593d-5f8e-392d-10zk-132c92mz9482", Name = "Admin", NormalizedName = "ADMIN" });
            builder.Entity<Role>().HasData(new Role { Id = "3d6asdas-5f8e-392d-10zk-132c92mz9482", Name = "Staff", NormalizedName = "STAFF" });

            var hasher = new PasswordHasher<User>();

            builder.Entity<User>().HasData(
                new User
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "nobel_manager",
                    NormalizedUserName = "nobel_manager".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "nobelmanager"),
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );

            #region Languages

            builder.Entity<Language>().HasData(
                new Language
                {
                    Id = 1,
                    Name = "AZ",
                    Enabled = true
                },
                new Language
                {
                    Id = 2,
                    Name = "EN",
                    Enabled = true
                }
            );

            #endregion

            #region Language Resource

            builder.Entity<LanguageResource>().HasData(
                new LanguageResource
                {
                    Id = 1,
                    ContentKey = "BecauseWeCare",
                    Content_AZ = "Çünki qayğı göstəririk",
                    Content_RU = "Потому что мы заботимся",
                    Content_EN = "Because we care",
                    Content_TR = "Çünkü umursuyoruz"
                },
                new LanguageResource
                {
                    Id = 2,
                    ContentKey = "ReadMore",
                    Content_AZ = "Ətraflı",
                    Content_RU = "Подробнее",
                    Content_EN = "Read more",
                    Content_TR = "Devamını oku"
                },
                new LanguageResource
                {
                    Id = 3,
                    ContentKey = "Contact",
                    Content_AZ = "Əlaqə",
                    Content_RU = "Контакт",
                    Content_EN = "Contact",
                    Content_TR = "İletişim"
                },
                new LanguageResource
                {
                    Id = 4,
                    ContentKey = "NewsArchive",
                    Content_AZ = "Xəbər arxivi",
                    Content_RU = "Архив новостей",
                    Content_EN = "News Archive",
                    Content_TR = "Haber arşivi"
                },
                new LanguageResource
                {
                    Id = 5,
                    ContentKey = "RecentNews",
                    Content_AZ = "Son xəbərlər",
                    Content_RU = "Свежие новости",
                    Content_EN = "Recent News",
                    Content_TR = "Son haberler"
                },
                new LanguageResource
                {
                    Id = 6,
                    ContentKey = "WhoWeAre",
                    Content_AZ = "Biz kimik",
                    Content_RU = "Кто мы есть",
                    Content_EN = "Who we are",
                    Content_TR = "Biz kimiz"
                },
                new LanguageResource
                {
                    Id = 7,
                    ContentKey = "OurProjects",
                    Content_AZ = "Proyektlər",
                    Content_RU = "Наши проекты",
                    Content_EN = "Our projects",
                    Content_TR = "Projeler"
                },
                new LanguageResource
                {
                    Id = 8,
                    ContentKey = "OurBusiness",
                    Content_AZ = "İşlərimiz",
                    Content_RU = "Наш бизнес",
                    Content_EN = "Our business",
                    Content_TR = "İşlerimiz"
                },
                new LanguageResource
                {
                    Id = 9,
                    ContentKey = "FollowUs",
                    Content_AZ = "Bizi izləyin",
                    Content_RU = "Подписывайтесь на нас",
                    Content_EN = "Follow us",
                    Content_TR = "Bizi takip et"
                },
                new LanguageResource
                {
                    Id = 10,
                    ContentKey = "LegalNotice",
                    Content_AZ = "Qanuni bildiriş",
                    Content_RU = "Правовая информация",
                    Content_EN = "Legal Notice",
                    Content_TR = "Yasal Uyarı"
                },
                 new LanguageResource
                 {
                     Id = 11,
                     ContentKey = "GetInTouch",
                     Content_AZ = "Əlaqədə olmaq",
                     Content_RU = "Связаться",
                     Content_EN = "Get in touch",
                     Content_TR = "Temasta olmak"
                 },
                 new LanguageResource
                 {
                     Id = 12,
                     ContentKey = "CareerTips",
                     Content_AZ = "Karyera məsləhətləri",
                     Content_RU = "Советы по карьере",
                     Content_EN = "Career tips",
                     Content_TR = "Kariyer ipuçları"
                 },
                 new LanguageResource
                 {
                     Id = 13,
                     ContentKey = "Send",
                     Content_AZ = "Göndər",
                     Content_RU = "Послать",
                     Content_EN = "Send",
                     Content_TR = "Gönder"
                 },
                 new LanguageResource
                 {
                     Id = 14,
                     ContentKey = "GoToTop",
                     Content_AZ = "Üstə gedin",
                     Content_RU = "Наверх",
                     Content_EN = "Go to top",
                     Content_TR = "Başa gitmek"
                 },
                 new LanguageResource
                 {
                     Id = 15,
                     ContentKey = "PrivacyNotice",
                     Content_AZ = "Gizlilik Bildirişi",
                     Content_RU = "Уведомление о конфиденциальности",
                     Content_EN = "Privacy Notice",
                     Content_TR = "Gizlilik Bildirimi"
                 },
                 new LanguageResource
                 {
                     Id = 16,
                     ContentKey = "CookiesPolicy",
                     Content_AZ = "Gizlilik Bildirişi",
                     Content_RU = "Политика использования файлов cookie",
                     Content_EN = "Cookies Policy",
                     Content_TR = "Gizlilik Bildirimi"
                 },
                 new LanguageResource
                 {
                     Id = 17,
                     ContentKey = "ApplyNow",
                     Content_AZ = "İndi müraciət et",
                     Content_RU = "Политика исполПрименить сейчас",
                     Content_EN = "Apply now",
                     Content_TR = "Şimdi uygula"
                 },
                 new LanguageResource
                 {
                     Id = 18,
                     ContentKey = "Summary",
                     Content_AZ = "Xülasə",
                     Content_RU = "Резюме",
                     Content_EN = "Apply now",
                     Content_TR = "Özet"
                 },
                  new LanguageResource
                  {
                      Id = 19,
                      ContentKey = "ResultFor",
                      Content_AZ = "Axtarış üçün nəticə",
                      Content_RU = "Результат для",
                      Content_EN = "Result for",
                      Content_TR = "Arama Sonuçu"
                  },
                   new LanguageResource
                   {
                       Id = 20,
                       ContentKey = "ResultsFound",
                       Content_AZ = "Nəticə tapıldı",
                       Content_RU = "Результаты найдены",
                       Content_EN = "Results found",
                       Content_TR = "Sonuç bulundu"
                   },
                    new LanguageResource
                    {
                        Id = 21,
                        ContentKey = "CommunityNews",
                        Content_AZ = "Icma xəbərləri",
                        Content_RU = "Новости сообщества",
                        Content_EN = "Community News",
                        Content_TR = "Topluluk haberleri"
                    },
                     new LanguageResource
                     {
                         Id = 22,
                         ContentKey = "AreaOfActivity",
                         Content_AZ = "Əsas fəaliyyət sahələri",
                         Content_RU = "Ключевые направления деятельности",
                         Content_EN = "Key areas of activity",
                         Content_TR = "Anahtar faaliyet alanları"
                     },
                     new LanguageResource
                     {
                         Id = 23,
                         ContentKey = "AreaOfActivityDescription",
                         Content_AZ = "Yeni strategiya davamlılığa təkmil yanaşmamızı dəstəkləyən üç əsas fəaliyyət sahəsi ətrafında qurulub",
                         Content_RU = "Новая стратегия построена вокруг трех ключевых областей деятельности, которые поддерживают наш расширенный подход к устойчивости",
                         Content_EN = "The new strategy is built around three key areas of activity that support our enhanced approach to sustainability",
                         Content_TR = "Yeni strateji, sürdürülebilirliğe yönelik gelişmiş yaklaşımımızı destekleyen üç temel faaliyet alanı etrafında inşa edilmiştir"
                     },
                     new LanguageResource
                     {
                         Id = 24,
                         ContentKey = "ApplySuccessfullyCompleted",
                         Content_AZ = "ApplySuccessfullyCompleted_AZ",
                         Content_RU = "ApplySuccessfullyCompleted_RU",
                         Content_EN = "ApplySuccessfullyCompleted_EN",
                         Content_TR = "ApplySuccessfullyCompleted_TR"
                     },
                     new LanguageResource
                     {
                         Id = 25,
                         ContentKey = "FillAllRequiredBlanks",
                         Content_AZ = "FillAllRequiredBlanks_AZ",
                         Content_RU = "FillAllRequiredBlanks_RU",
                         Content_EN = "FillAllRequiredBlanks_EN",
                         Content_TR = "FillAllRequiredBlanks_TR"
                     }
            );

            #endregion
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // for entities that implements ITiming,
                // set UpdatedAt / CreatedAt appropriately
                if (entry.Entity is ITiming trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.UpdatedAt = utcNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("CreatedAt").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.CreatedAt = utcNow;
                            trackable.UpdatedAt = utcNow;
                            break;
                    }
                }
            }
        }
    }
}