using Core.Constants;
using Core.Extensions;
using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        private readonly NobelContext _context;

        public NewsRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<News>> GetAllForNewsAsync(DateTime? from, DateTime? to)
        {
            return await _context.News.Where(n => ((from != null) ? n.ActionDate >= from : true && (to != null) ? n.ActionDate <= to : true) && n.NewsType == NewsType.News).ToListAsync();
        }

        public async Task<List<News>> GetAllForCommunityAsync()
        {
            return await _context.News.Where(n => n.NewsType == NewsType.Community).ToListAsync();
        }

        public async Task<News> GetBySlugAsync(string slug)
        {
            return await _context.News.FirstOrDefaultAsync(n => n.Slug == slug);
        }

        public string GenerateSlug(string title, News news)
        {
            StringBuilder slug = new StringBuilder(title.Slugify());
            return slug.Append("-" + news.Id).ToString();
        }

        public async Task<List<News>> GetAllForHome()
        {
            return await _context.News.Where(n => n.ShowOnHome).OrderByDescending(c => c.ActionDate).ToListAsync();
        }

        public async Task<List<News>> GetAllForMedia()
        {
            return await _context.News.OrderByDescending(c => c.ActionDate).Take(9).ToListAsync();
        }

        public async Task<List<News>> GetAllRecentNewsForComponentAsync(int id)
        {
            return await _context.News
                                      .Where(n => n.Id != id)
                                      .OrderByDescending(n => n.ActionDate)
                                      .ToListAsync();
        }

        public async Task<Tuple<DateTime?, DateTime?>> GetDateTimesForNews(string dateRange)
        {
            DateTime? from = null;
            DateTime? to = null;

            if (dateRange != null)
            {
                from = DateTime.ParseExact(dateRange.Substring(0, 10), "dd.MM.yyyy", null);
                to = DateTime.ParseExact(dateRange.Substring(13, 10), "dd.MM.yyyy", null);
            }

            return new Tuple<DateTime?, DateTime?>(from, to);
        }
    }
}
