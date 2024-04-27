using Core;
using Core.Constants;
using Core.Models;
using Manage.MiddlewareFilters;
using Manage.ViewModels.Media;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class MediaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MediaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new MediaIndexViewModel
            {
                News = await _unitOfWork.News.GetAllForMedia(),
                MediaComponents = await _unitOfWork.MediaComponent.GetAllByIsActiveAsync(),
                Flatpages = await _unitOfWork.Flatpages.GetAllByPageAsync(Page.Media),
                DynamicPages = await _unitOfWork.DynamicPages.GetAllByPageAsync(Page.Media)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> News(MediaNewsViewModel model, int page = 1)
        {
            const int pageSize = 6;

            var dateTimes = await _unitOfWork.News.GetDateTimesForNews(model.DateRange);
            var news = (await _unitOfWork.News.GetAllForNewsAsync(dateTimes.Item1, dateTimes.Item2)).OrderByDescending(n => n.ActionDate).ToList();

            var pager = new Pager(news.Count, page, pageSize);
            news = news.Skip(pager.RecSkip).Take(pager.PageSize).ToList();

            model = new MediaNewsViewModel
            {
                News = news,
                Pager = pager
            };

            return View(model);
        }


        [HttpGet("{culture}/media/news/{slug}")]
        public async Task<IActionResult> NewsComponent(string slug)
        {
            var news = await _unitOfWork.News.GetBySlugAsync(slug);
            if (news == null) return NotFound();

            var model = new MediaNewsComponentViewModel
            {
                News = news,
                RecentNews = await _unitOfWork.News.GetAllRecentNewsForComponentAsync(news.Id)
            };

            return View(model);
        }

        [HttpGet("{culture}/media/insights")]
        public async Task<IActionResult> PublicationReport(int page = 1)
        {
            const int pageSize = 6;

            var publicationReports = (await _unitOfWork.PublicationReport.GetAllAsync()).OrderByDescending(pr => pr.ActionDate).ToList();

            var pager = new Pager(publicationReports.Count, page, pageSize);
            publicationReports = publicationReports.Skip(pager.RecSkip).Take(pager.PageSize).ToList();

            var model = new MediaPublicationReportViewModel
            {
                PublicationReports = publicationReports,
                Pager = pager
            };

            return View(model);
        }


        [HttpGet("{culture}/media/insights/{slug}")]
        public async Task<IActionResult> PublicationReportComponent(string slug)
        {
            var publicationReport = await _unitOfWork.PublicationReport.GetBySlugAsync(slug);
            if (publicationReport == null) return NotFound();

            Core.Constants.Language langEnum = _unitOfWork.Languages.GetCurrentThreadLang();

            var model = new MediaPublicationReportComponentViewModel
            {
                PublicationReport = publicationReport,
                RecentPublicationReports = await _unitOfWork.PublicationReport.GetAllRecentPublicationReportsForComponentAsync(publicationReport.Id),
                PublicationReportPdfs = await _unitOfWork.PublicationReportPdf.GetAllByPublicationReportIdAsync(publicationReport.Id, langEnum),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ImageGallery()
        {
            var model = new MediaImageGalleryViewModel
            {
                ImageGalleryComponents = await _unitOfWork.ImageGalleryComponent.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet("{culture}/media/imagegallery/{slug}")]
        public async Task<IActionResult> ImageGalleryComponent(string slug)
        {
            var imageGalleryComponent = await _unitOfWork.ImageGalleryComponent.GetBySlugAsync(slug);
            if (imageGalleryComponent == null) return NotFound();

            var model = new MediaImageGalleryComponentViewModel
            {
                ImageGalleryComponent = imageGalleryComponent
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> VideoGallery()
        {
            var model = new MediaVideoGalleryViewModel
            {
                VideoGalleryComponents = await _unitOfWork.VideoGalleryComponent.GetAllForMedia()
            };

            return View(model);
        }
    }
}
