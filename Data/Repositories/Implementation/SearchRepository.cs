using Core.Constants;
using Core.Models.Search;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class SearchRepository : ISearchRepository
    {
        private readonly NobelContext _context;

        public SearchRepository(NobelContext context)
        {
            _context = context;
        }

        public async Task<List<SearchResultModel>> GetResultsAsync(string query)
        {
            List<SearchResultModel> results = new List<SearchResultModel>();

            var currentCulture = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            results.AddRange(await _context.AboutComponent
                                           .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                           .Select(x => new SearchResultModel
                                           {
                                               Title_AZ = x.Title_AZ,
                                               Title_RU = x.Title_RU,
                                               Title_EN = x.Title_EN,
                                               Title_TR = x.Title_TR,
                                               Content_AZ = x.Content_AZ,
                                               Content_RU = x.Content_RU,
                                               Content_EN = x.Content_EN,
                                               Content_TR = x.Content_TR,
                                               Link = $"{currentCulture}/about"
                                           })
                                           .ToListAsync());

            results.AddRange(await _context.BoardDirectorComponent
                                           .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                           .Select(x => new SearchResultModel
                                           {
                                               Title_AZ = x.Title_AZ,
                                               Title_RU = x.Title_RU,
                                               Title_EN = x.Title_EN,
                                               Title_TR = x.Title_TR,
                                               Content_AZ = x.Content_AZ,
                                               Content_RU = x.Content_RU,
                                               Content_EN = x.Content_EN,
                                               Content_TR = x.Content_TR,
                                               Link = $"{currentCulture}/boarddirector"
                                           })
                                           .ToListAsync());

            results.AddRange(await _context.CareerComponents
                                           .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                           .Select(x => new SearchResultModel
                                           {
                                               Title_AZ = x.Title_AZ,
                                               Title_RU = x.Title_RU,
                                               Title_EN = x.Title_EN,
                                               Title_TR = x.Title_TR,
                                               Content_AZ = x.Content_AZ,
                                               Content_RU = x.Content_RU,
                                               Content_EN = x.Content_EN,
                                               Content_TR = x.Content_TR,
                                               Link = $"{currentCulture}/career/{x.Slug}"
                                           })
                                           .ToListAsync());

            results.AddRange(await _context.CareerTipComponents
                                           .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                           .Select(x => new SearchResultModel
                                           {
                                               Title_AZ = x.Title_AZ,
                                               Title_RU = x.Title_RU,
                                               Title_EN = x.Title_EN,
                                               Title_TR = x.Title_TR,
                                               Content_AZ = x.Content_AZ,
                                               Content_RU = x.Content_RU,
                                               Content_EN = x.Content_EN,
                                               Content_TR = x.Content_TR,
                                               Link = $"{currentCulture}/career/tip/{x.Id}"
                                           })
                                           .ToListAsync());

            results.AddRange(await _context.CommunityComponent
                                           .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                           .Select(x => new SearchResultModel
                                           {
                                               Title_AZ = x.Title_AZ,
                                               Title_RU = x.Title_RU,
                                               Title_EN = x.Title_EN,
                                               Title_TR = x.Title_TR,
                                               Content_AZ = x.Content_AZ,
                                               Content_RU = x.Content_RU,
                                               Content_EN = x.Content_EN,
                                               Content_TR = x.Content_TR,
                                               Link = $"{currentCulture}/community"
                                           })
                                           .ToListAsync());

            results.AddRange(await _context.Companies
                                           .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                           .Select(x => new SearchResultModel
                                           {
                                               Title_AZ = x.Title_AZ,
                                               Title_RU = x.Title_RU,
                                               Title_EN = x.Title_EN,
                                               Title_TR = x.Title_TR,
                                               Content_AZ = x.Content_AZ,
                                               Content_RU = x.Content_RU,
                                               Content_EN = x.Content_EN,
                                               Content_TR = x.Content_TR,
                                               Link = $"{currentCulture}/ourbusiness/company/{x.Slug}"
                                           })
                                           .ToListAsync());

            results.AddRange(await _context.CompanyServices
                                           .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query))
                                           .Select(x => new SearchResultModel
                                           {
                                               Title_AZ = x.Title_AZ,
                                               Title_RU = x.Title_RU,
                                               Title_EN = x.Title_EN,
                                               Title_TR = x.Title_TR,
                                               Link = $"{currentCulture}/ourbusiness"
                                           })
                                           .ToListAsync());

            results.AddRange(await _context.CorporateGovernanceComponent
                                           .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                           .Select(x => new SearchResultModel
                                           {
                                               Title_AZ = x.Title_AZ,
                                               Title_RU = x.Title_RU,
                                               Title_EN = x.Title_EN,
                                               Title_TR = x.Title_TR,
                                               Content_AZ = x.Content_AZ,
                                               Content_RU = x.Content_RU,
                                               Content_EN = x.Content_EN,
                                               Content_TR = x.Content_TR,
                                               Link = $"{currentCulture}/corporategovernance"
                                           })
                                           .ToListAsync());

            results.AddRange(await _context.EnvironmentComponent
                                           .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                           .Select(x => new SearchResultModel
                                           {
                                               Title_AZ = x.Title_AZ,
                                               Title_RU = x.Title_RU,
                                               Title_EN = x.Title_EN,
                                               Title_TR = x.Title_TR,
                                               Content_AZ = x.Content_AZ,
                                               Content_RU = x.Content_RU,
                                               Content_EN = x.Content_EN,
                                               Content_TR = x.Content_TR,
                                               Link = $"{currentCulture}/sustainability"
                                           })
                                           .ToListAsync());

            results.AddRange(await _context.EnvironmentSubComponents
                                           .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                           .Select(x => new SearchResultModel
                                           {
                                               Title_AZ = x.Title_AZ,
                                               Title_RU = x.Title_RU,
                                               Title_EN = x.Title_EN,
                                               Title_TR = x.Title_TR,
                                               Content_AZ = x.Content_AZ,
                                               Content_RU = x.Content_RU,
                                               Content_EN = x.Content_EN,
                                               Content_TR = x.Content_TR,
                                               Link = $"{currentCulture}/environment/{x.Slug}"
                                           })
                                           .ToListAsync());

            results.AddRange(await _context.EthicsComplianceComponent
                                           .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                           .Select(x => new SearchResultModel
                                           {
                                               Title_AZ = x.Title_AZ,
                                               Title_RU = x.Title_RU,
                                               Title_EN = x.Title_EN,
                                               Title_TR = x.Title_TR,
                                               Content_AZ = x.Content_AZ,
                                               Content_RU = x.Content_RU,
                                               Content_EN = x.Content_EN,
                                               Content_TR = x.Content_TR,
                                               Link = $"{currentCulture}/sustainability"
                                           })
                                           .ToListAsync());

            results.AddRange(await _context.EthicsComplianceSubComponents
                                           .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                           .Select(x => new SearchResultModel
                                           {
                                               Title_AZ = x.Title_AZ,
                                               Title_RU = x.Title_RU,
                                               Title_EN = x.Title_EN,
                                               Title_TR = x.Title_TR,
                                               Content_AZ = x.Content_AZ,
                                               Content_RU = x.Content_RU,
                                               Content_EN = x.Content_EN,
                                               Content_TR = x.Content_TR,
                                               Link = $"{currentCulture}/ethicsandcompliance/{x.Slug}"
                                           })
                                           .ToListAsync());

            results.AddRange(await _context.ExecutiveManagementComponent
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/executivemanagement"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.Flatpages
                                          .Where(x => x.BannerTitle_AZ.Contains(query) ||
                                                       x.BannerTitle_RU.Contains(query) ||
                                                       x.BannerTitle_EN.Contains(query) ||
                                                       x.BannerTitle_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.BannerTitle_AZ,
                                              Title_RU = x.BannerTitle_RU,
                                              Title_EN = x.BannerTitle_EN,
                                              Title_TR = x.BannerTitle_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = x.URL
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.HistoryComponents
                                          .Where(x => x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/history"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.HumanResourceComponent
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/humanresource"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.LegalNoticeComponent
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/legalnotice"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.Managers
                                          .Where(x => (x.Name_AZ.Contains(query) ||
                                                       x.Name_RU.Contains(query) ||
                                                       x.Name_EN.Contains(query) ||
                                                       x.Name_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query)) &&
                                                       x.Type == ManagerType.Board)
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Name_AZ,
                                              Title_RU = x.Name_AZ,
                                              Title_EN = x.Name_AZ,
                                              Title_TR = x.Name_AZ,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/boarddirector"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.Managers
                                          .Where(x => (x.Name_AZ.Contains(query) ||
                                                       x.Name_RU.Contains(query) ||
                                                       x.Name_EN.Contains(query) ||
                                                       x.Name_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query)) &&
                                                      x.Type == ManagerType.Executive)
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Name_AZ,
                                              Title_RU = x.Name_AZ,
                                              Title_EN = x.Name_AZ,
                                              Title_TR = x.Name_AZ,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/executivemanagement"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.MediaComponents
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/media/{x.Link}"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.News
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/media/news/{x.Slug}"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.NobelHeritages
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/nobelheritage"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.OurBusinesses
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/{x.Link}"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.OurHistoryComponent
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.ContentWWA_AZ.Contains(query) ||
                                                       x.ContentWWA_RU.Contains(query) ||
                                                       x.ContentWWA_EN.Contains(query) ||
                                                       x.ContentWWA_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.ContentWWA_AZ,
                                              Content_RU = x.ContentWWA_RU,
                                              Content_EN = x.ContentWWA_EN,
                                              Content_TR = x.ContentWWA_TR,
                                              Link = $"{currentCulture}/whoweare"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.OurProjectComponent
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/whatwedo"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.Projects
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/project/{x.Slug}"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.PublicationReports
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/media/publicationreport/{x.Slug}"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.SafetyComponent
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/sustainability"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.SafetySubComponents
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/safety/{x.Slug}"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.SustainabilityReport
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/sustainability"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.SustainableDevelopment
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/sustainability"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.SustainableGoals
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Link = $"{currentCulture}/sustainability"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.Testimonials
                                          .Where(x => x.Writer_AZ.Contains(query) ||
                                                       x.Writer_RU.Contains(query) ||
                                                       x.Writer_EN.Contains(query) ||
                                                       x.Writer_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Writer_AZ,
                                              Title_RU = x.Writer_RU,
                                              Title_EN = x.Writer_EN,
                                              Title_TR = x.Writer_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/nobelheritage"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.Vacancies
                                          .Where(x => (x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query)) &&
                                                       (x.StartDate < DateTime.Now && x.EndDate > DateTime.Now))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/career/{_context.CareerComponents.FirstOrDefault(c => c.ShowVacancies).Slug}"
                                          })
                                          .ToListAsync());

            results.AddRange(await _context.VMVComponent
                                          .Where(x => x.Title_AZ.Contains(query) ||
                                                       x.Title_RU.Contains(query) ||
                                                       x.Title_EN.Contains(query) ||
                                                       x.Title_TR.Contains(query) ||
                                                       x.Content_AZ.Contains(query) ||
                                                       x.Content_RU.Contains(query) ||
                                                       x.Content_EN.Contains(query) ||
                                                       x.Content_TR.Contains(query))
                                          .Select(x => new SearchResultModel
                                          {
                                              Title_AZ = x.Title_AZ,
                                              Title_RU = x.Title_RU,
                                              Title_EN = x.Title_EN,
                                              Title_TR = x.Title_TR,
                                              Content_AZ = x.Content_AZ,
                                              Content_RU = x.Content_RU,
                                              Content_EN = x.Content_EN,
                                              Content_TR = x.Content_TR,
                                              Link = $"{currentCulture}/vmv"
                                          })
                                          .ToListAsync());

            return results;
        }
    }
}
