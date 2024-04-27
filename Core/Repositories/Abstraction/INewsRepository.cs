using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface INewsRepository : IRepository<News>
    {
        Task<News> GetBySlugAsync(string slug);
        Task<List<News>> GetAllForHome();
        Task<List<News>> GetAllForMedia();
        string GenerateSlug(string title, News news);
        Task<List<News>> GetAllRecentNewsForComponentAsync(int id);
        Task<List<News>> GetAllForNewsAsync(DateTime? from, DateTime? to);
        Task<List<News>> GetAllForCommunityAsync();
        Task<Tuple<DateTime?, DateTime?>> GetDateTimesForNews(string dateRange);
    }
}
