using Core.Models.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ISearchRepository
    {
        Task<List<SearchResultModel>> GetResultsAsync(string query);
    }
}
