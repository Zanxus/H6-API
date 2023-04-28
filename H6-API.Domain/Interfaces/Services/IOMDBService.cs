using H6_API.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6_API.Domain.Interfaces.Services
{
    public interface IOMDBService
    {
        Task<List<OMDBSearchMediaResponse>?> SearchMedia(string searchQuery);
    }
}
