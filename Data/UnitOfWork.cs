using Core;
using Core.Models;
using Core.Repositories;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Data.Repositories.Implementation;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly NobelContext _context;

        public UnitOfWork(UserManager<User> userManager,
            RoleManager<Role> roleManager,
            NobelContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        private IUserRepository user;
        public IUserRepository Users => user ??= new UserRepository(_userManager, _roleManager);


        private IRoleRepository role;
        public IRoleRepository Roles => role ??= new RoleRepository(_roleManager);


        private INewsRepository news;
        public INewsRepository News => news ??= new NewsRepository(_context);


        private IPageMainPhotoRepository pageMainPhoto;
        public IPageMainPhotoRepository PageMainPhoto => pageMainPhoto ??= new PageMainPhotoRepository(_context);


        private IVMVComponentRepository vmvComponent;
        public IVMVComponentRepository VMVComponent => vmvComponent ??= new VMVComponentRepository(_context);


        private IVMVComponentPhotoRepository vmvComponentPhoto;
        public IVMVComponentPhotoRepository VMVComponentPhoto => vmvComponentPhoto ??= new VMVComponentPhotoRepository(_context);


        private IAboutComponentRepository aboutComponent;
        public IAboutComponentRepository AboutComponent => aboutComponent ??= new AboutComponentRepository(_context);


        private ITestimonialRepository testimonial;
        public ITestimonialRepository Testimonials => testimonial ??= new TestimonialRepository(_context);


        private INobelHeritageRepository nobelHeritage;
        public INobelHeritageRepository NobelHeritage => nobelHeritage ??= new NobelHeritageRepository(_context);


        private INobelHeritagePhotoRepository nobelHeritagePhoto;
        public INobelHeritagePhotoRepository NobelHeritagePhoto => nobelHeritagePhoto ??= new NobelHeritagePhotoRepository(_context);

        private IHistoryComponentRepository historyComponent;
        public IHistoryComponentRepository HistoryComponent => historyComponent ??= new HistoryComponentRepository(_context);


        private IBoardDirectorComponentRepository boardDirectorComponent;
        public IBoardDirectorComponentRepository BoardDirectorComponent => boardDirectorComponent ??= new BoardDirectorComponentRepository(_context);


        private IManagerRepository managers;
        public IManagerRepository Managers => managers ??= new ManagerRepository(_context);


        private ICorporateGovernanceComponentRepository corporateGovernanceComponent;
        public ICorporateGovernanceComponentRepository CorporateGovernanceComponent => corporateGovernanceComponent ??= new CorporateGovernanceComponentRepository(_context);


        private IExecutiveManagementComponentRepository executiveManagementComponent;
        public IExecutiveManagementComponentRepository ExecutiveManagementComponent => executiveManagementComponent ??= new ExecutiveManagementComponentRepository(_context);


        private IOurBusinessRepository ourBusinesses;
        public IOurBusinessRepository OurBusinesses => ourBusinesses ??= new OurBusinessRepository(_context);


        private IOurProjectComponentRepository ourProjectComponent;
        public IOurProjectComponentRepository OurProjectComponent => ourProjectComponent ??= new OurProjectComponentRepository(_context);


        private IProjectRepository projects;
        public IProjectRepository Projects => projects ??= new ProjectRepository(_context);


        private ISustainableDevelopmentRepository sustainableDevelopment;
        public ISustainableDevelopmentRepository SustainableDevelopment => sustainableDevelopment ??= new SustainableDevelopmentRepository(_context);


        private ISustainabilityReportRepository sustainabilityReport;
        public ISustainabilityReportRepository SustainabilityReport => sustainabilityReport ??= new SustainabilityReportRepository(_context);


        private ICompanyRepository companies;
        public ICompanyRepository Companies => companies ??= new CompanyRepository(_context);


        private ICarouselRepository carousels;
        public ICarouselRepository Carousels => carousels ??= new CarouselRepository(_context);


        private ILanguageRepository languages;
        public ILanguageRepository Languages => languages ??= new LanguageRepository(_context);

        private ISafetyComponentRepository safetyComponent;
        public ISafetyComponentRepository SafetyComponent => safetyComponent ??= new SafetyComponentRepository(_context);


        private ISafetySubComponentRepository safetySubComponent;
        public ISafetySubComponentRepository SafetySubComponent => safetySubComponent ??= new SafetySubComponentRepository(_context);


        private ISafetySubComponentPhotoRepository safetySubComponentPhoto;
        public ISafetySubComponentPhotoRepository SafetySubComponentPhoto => safetySubComponentPhoto ??= new SafetySubComponentPhotoRepository(_context);


        private IEnvironmentComponentRepository environmentComponent;
        public IEnvironmentComponentRepository EnvironmentComponent => environmentComponent ??= new EnvironmentComponentRepository(_context);


        private IEnvironmentSubComponentRepository environmentSubComponent;
        public IEnvironmentSubComponentRepository EnvironmentSubComponent => environmentSubComponent ??= new EnvironmentSubComponentRepository(_context);


        private IEnvironmentSubComponentPhotoRepository environmentSubComponentPhoto;
        public IEnvironmentSubComponentPhotoRepository EnvironmentSubComponentPhoto => environmentSubComponentPhoto ??= new EnvironmentSubComponentPhotoRepository(_context);


        private IHumanResourceComponentRepository humanResourceComponent;
        public IHumanResourceComponentRepository HumanResourceComponent => humanResourceComponent ??= new HumanResourceComponentRepository(_context);


        private IHumanResourceComponentPhotoRepository humanResourceComponentPhoto;
        public IHumanResourceComponentPhotoRepository HumanResourceComponentPhoto => humanResourceComponentPhoto ??= new HumanResourceComponentPhotoRepository(_context);


        private IOurHistoryComponentRepository ourHistoryComponent;
        public IOurHistoryComponentRepository OurHistoryComponent => ourHistoryComponent ??= new OurHistoryComponentRepository(_context);

        private ICommunityComponentRepository communityComponent;
        public ICommunityComponentRepository CommunityComponent => communityComponent ??= new CommunityComponentRepository(_context);


        private ICommunityComponentPhotoRepository communityComponentPhoto;
        public ICommunityComponentPhotoRepository CommunityComponentPhoto => communityComponentPhoto ??= new CommunityComponentPhotoRepository(_context);


        private IEthicsComplianceComponentRepository ethicsComplianceComponent;
        public IEthicsComplianceComponentRepository EthicsComplianceComponent => ethicsComplianceComponent ??= new EthicsComplianceComponentRepository(_context);


        private IEthicsComplianceSubComponentRepository ethicsComplianceSubComponent;
        public IEthicsComplianceSubComponentRepository EthicsComplianceSubComponent => ethicsComplianceSubComponent ??= new EthicsComplianceSubComponentRepository(_context);


        private IEthicsComplianceSubComponentPdfsRepostiory ethicsComplianceSubComponentPdfs;
        public IEthicsComplianceSubComponentPdfsRepostiory EthicsComplianceSubComponentPdfs => ethicsComplianceSubComponentPdfs ??= new EthicsComplianceSubComponentPdfsRepostiory(_context);


        private ILegalNoticeComponentRepository legalNoticeComponent;
        public ILegalNoticeComponentRepository LegalNoticeComponent => legalNoticeComponent ??= new LegalNoticeComponentRepository(_context);


        private ICompanyServiceRepository companyServices;
        public ICompanyServiceRepository CompanyServices => companyServices ??= new CompanyServiceRepository(_context);

        private ICareerComponentRepository careerComponent;
        public ICareerComponentRepository CareerComponent => careerComponent ??= new CareerComponentRepository(_context);


        private IVacancyRepository vacancy;
        public IVacancyRepository Vacancy => vacancy ??= new VacancyRepository(_context);


        private ICareerTipComponentRepository careerTipComponent;
        public ICareerTipComponentRepository CareerTipComponent => careerTipComponent ??= new CareerTipComponentRepository(_context);


        private ISustainableGoalRepository sustainableGoals;
        public ISustainableGoalRepository SustainableGoals => sustainableGoals ??= new SustainableGoalRepository(_context);



        private INavTitleComponentRepository navTitleComponent;
        public INavTitleComponentRepository NavTitleComponent => navTitleComponent ??= new NavTitleComponentRepository(_context);


        private INavComponentRepository navComponent;
        public INavComponentRepository NavComponent => navComponent ??= new NavComponentRepository(_context);


        private INavSubComponentRepository navSubComponent;
        public INavSubComponentRepository NavSubComponent => navSubComponent ??= new NavSubComponentRepository(_context);


        private IEthicsAndCompilanceApplyRepository ethicsAndCompilanceApplies;
        public IEthicsAndCompilanceApplyRepository EthicsAndCompilanceApplies => ethicsAndCompilanceApplies ??= new EthicsAndCompilanceApplyRepository(_context);


        private IMediaComponentRepository mediaComponent;
        public IMediaComponentRepository MediaComponent => mediaComponent ??= new MediaComponentRepository(_context);


        private IImageGalleryComponentRepository imageGalleryComponent;
        public IImageGalleryComponentRepository ImageGalleryComponent => imageGalleryComponent ??= new ImageGalleryComponentRepository(_context);


        private IImageGalleryComponentPhotoRepository imageGalleryComponentPhoto;
        public IImageGalleryComponentPhotoRepository ImageGalleryComponentPhoto => imageGalleryComponentPhoto ??= new ImageGalleryComponentPhotoRepository(_context);


        private IVideoGalleryComponentRepository videoGalleryComponent;
        public IVideoGalleryComponentRepository VideoGalleryComponent => videoGalleryComponent ??= new VideoGalleryComponentRepository(_context);


        private IPublicationReportRepository publicationReport;
        public IPublicationReportRepository PublicationReport => publicationReport ??= new PublicationReportRepository(_context);


        private IPublicationReportPdfRepository publicationReportPdf;
        public IPublicationReportPdfRepository PublicationReportPdf => publicationReportPdf ??= new PublicationReportPdfRepository(_context);


        private IContactMessageRepository contactMessages;
        public IContactMessageRepository ContactMessages => contactMessages ??= new ContactMessageRepository(_context);


        private ISiteConfigRepository siteConfig;
        public ISiteConfigRepository SiteConfig => siteConfig ??= new SiteConfigRepository(_context);


        private IHomeVideoComponentRepository homeVideoComponent;
        public IHomeVideoComponentRepository HomeVideoComponent => homeVideoComponent ??= new HomeVideoComponentRepository(_context);


        private ILanguageResourceRepository languageResource;
        public ILanguageResourceRepository LanguageResources => languageResource ??= new LanguageResourceRepository(_context);


        private IPageTabComponentRepository pageTabComponent;
        public IPageTabComponentRepository PageTabComponents => pageTabComponent ??= new PageTabComponentRepository(_context);


        private ISearchRepository search;
        public ISearchRepository Search => search ??= new SearchRepository(_context);


        private IVacancyApplyRepository vacancyApply;
        public IVacancyApplyRepository VacancyApplies => vacancyApply ??= new VacancyApplyRepository(_context);


        private IVacancyApplyFileRepository vacancyApplyFile;
        public IVacancyApplyFileRepository VacancyApplyFiles => vacancyApplyFile ??= new VacancyApplyFileRepository(_context);


        private IOurStrategyComponentRepository ourStrategyComponent;
        public IOurStrategyComponentRepository OurStrategyComponents => ourStrategyComponent ??= new OurStrategyComponentRepository(_context);


        private IKeyAreaComponentRepository keyAreaComponent;
        public IKeyAreaComponentRepository KeyAreaComponents => keyAreaComponent ??= new KeyAreaComponentRepository(_context);


        private IFlatpageRepository flatpage;
        public IFlatpageRepository Flatpages => flatpage ??= new FlatpageRepository(_context);


        private IDynamicPageRepository dynamicPage;
        public IDynamicPageRepository DynamicPages => dynamicPage ??= new DynamicPageRepository(_context);

        private IDynamicPageContentRepository dynamicPageContent;
        public IDynamicPageContentRepository DynamicPageContents => dynamicPageContent ??= new DynamicPageContentRepository(_context);


        private IMainSustainabilityReportRepository mainSustainabilityReport;
        public IMainSustainabilityReportRepository MainSustainabilityReport => mainSustainabilityReport ??= new MainSustainabilityReportRepository(_context);


        private ILifeAtNobelEnergyRepository lifeAtNobelEnergy;
        public ILifeAtNobelEnergyRepository LifeAtNobelEnergy => lifeAtNobelEnergy ??= new LifeAtNobelEnergyRepository(_context);


        private ILifeAtNobelEnergyPdfRepository lifeAtNobelEnergyPdf;
        public ILifeAtNobelEnergyPdfRepository LifeAtNobelEnergyPdf => lifeAtNobelEnergyPdf ??= new LifeAtNobelEnergyPdfRepository(_context);


        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
