using H6_API.Domain.DTO;
using H6_API.Domain.Interfaces.Repositories;
using H6_API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace H6_API.Infrastructure.Repositoies
{
    public class OMDBSearchMediaRepository : RepositoryBase<OMDBSearchMedia>, IOMDBSearchMediaRepository
    {
        private readonly HttpClient httpClient;

        public OMDBSearchMediaRepository(HttpClient httpClient, WatchMateDbContext dbContext) : base(dbContext)
        {
            this.httpClient = httpClient;
        }

        public Task<List<OMDBSearchMediaResponse>?> GetOMDBSearch(string SearchQuery)
        {
            using (httpClient)
            {
                return httpClient.GetAsync(SearchQuery).Result.Content.ReadFromJsonAsync<List<OMDBSearchMediaResponse>>();
            }
        }
    }
}
