using Core.Repositories;
using Core.Repositories.Abstraction;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        IRoleRepository Roles { get; }

        INewsRepository News { get; }

        IPageMainPhotoRepository PageMainPhoto { get; }

        IVMVComponentRepository VMVComponent { get; } 

        IVMVComponentPhotoRepository VMVComponentPhoto { get; }

        INobelHeritageRepository NobelHeritage { get; }

        INobelHeritagePhotoRepository NobelHeritagePhoto { get; }

        IAboutComponentRepository AboutComponent { get; }

        ITestimonialRepository Testimonials { get; }

        IHistoryComponentRepository HistoryComponent { get; }

        IBoardDirectorComponentRepository BoardDirectorComponent { get; }

        IManagerRepository Managers { get; }

        ICorporateGovernanceComponentRepository CorporateGovernanceComponent { get; }

        IExecutiveManagementComponentRepository ExecutiveManagementComponent { get; }

        IOurBusinessRepository OurBusinesses { get; }

        IOurProjectComponentRepository OurProjectComponent { get; }

        IProjectRepository Projects { get; }

        ISustainableDevelopmentRepository SustainableDevelopment { get; }

        ISustainabilityReportRepository SustainabilityReport { get; }

        IMainSustainabilityReportRepository MainSustainabilityReport { get; }

        ICompanyRepository Companies { get; }

        ICarouselRepository Carousels { get; }

        ILanguageRepository Languages { get; }
        ISafetyComponentRepository SafetyComponent { get; }

        ISafetySubComponentRepository SafetySubComponent { get; }

        ISafetySubComponentPhotoRepository SafetySubComponentPhoto { get; }

        IEnvironmentComponentRepository EnvironmentComponent { get; }

        IEnvironmentSubComponentRepository EnvironmentSubComponent { get; }

        IEnvironmentSubComponentPhotoRepository EnvironmentSubComponentPhoto { get; }

        IHumanResourceComponentRepository HumanResourceComponent { get; }

        IHumanResourceComponentPhotoRepository HumanResourceComponentPhoto { get; }

        IOurHistoryComponentRepository OurHistoryComponent { get; }

        ICommunityComponentRepository CommunityComponent { get; }

        ICommunityComponentPhotoRepository CommunityComponentPhoto { get; }

        IEthicsComplianceComponentRepository EthicsComplianceComponent { get; }

        IEthicsComplianceSubComponentRepository EthicsComplianceSubComponent { get; }

        IEthicsComplianceSubComponentPdfsRepostiory EthicsComplianceSubComponentPdfs { get; }

        ICareerComponentRepository CareerComponent { get; }

        IVacancyRepository Vacancy { get; }

        ICareerTipComponentRepository CareerTipComponent { get; }

        ILegalNoticeComponentRepository LegalNoticeComponent { get; }

        ICompanyServiceRepository CompanyServices { get; }

        ISustainableGoalRepository SustainableGoals { get; }

        INavTitleComponentRepository NavTitleComponent { get; }

        INavComponentRepository NavComponent { get; }

        INavSubComponentRepository NavSubComponent { get; }

        IEthicsAndCompilanceApplyRepository EthicsAndCompilanceApplies { get; }

        IMediaComponentRepository MediaComponent { get; }

        IImageGalleryComponentRepository ImageGalleryComponent { get; }

        IImageGalleryComponentPhotoRepository ImageGalleryComponentPhoto { get; }

        IVideoGalleryComponentRepository VideoGalleryComponent { get; }

        IPublicationReportRepository PublicationReport { get; }

        IPublicationReportPdfRepository PublicationReportPdf { get; }

        ILifeAtNobelEnergyRepository LifeAtNobelEnergy { get; }

        ILifeAtNobelEnergyPdfRepository LifeAtNobelEnergyPdf { get; }

        IContactMessageRepository ContactMessages { get; }

        ISiteConfigRepository SiteConfig { get; }

        IHomeVideoComponentRepository HomeVideoComponent { get; }

        ILanguageResourceRepository LanguageResources { get; }

        IPageTabComponentRepository PageTabComponents { get; }

        ISearchRepository Search { get; }

        IVacancyApplyRepository VacancyApplies { get; }

        IVacancyApplyFileRepository VacancyApplyFiles { get; }

        IOurStrategyComponentRepository OurStrategyComponents { get; }

        IKeyAreaComponentRepository KeyAreaComponents { get; }

        IFlatpageRepository Flatpages { get; }

        IDynamicPageRepository DynamicPages { get; }

        IDynamicPageContentRepository DynamicPageContents { get; }

        Task CommitAsync();
    }
}
