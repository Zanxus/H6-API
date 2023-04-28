using H6_API.Domain.DTO;
using H6_API.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace H6_API.Application.Services
{
    public class OMDBService : IOMDBService
    {
        private readonly HttpClient httpClient;

        public OMDBService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public Task<List<OMDBSearchMediaResponse>?> SearchMedia(string searchQuery)
        {
            using (httpClient)
            {
                return httpClient.GetAsync(searchQuery).Result.Content.ReadFromJsonAsync<List<OMDBSearchMediaResponse>>();
            }
        }
    }
}
