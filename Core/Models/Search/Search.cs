using System.Collections.Generic;

namespace Core.Models.Search
{
    public class Search
    {
        public string Query { get; set; }

        public List<SearchResultModel> Results { get; set; }
    }
}
