using H6_API.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6_API.Domain.Interfaces.Repositories
{
    public interface IOMDBSearchMediaRepository :IRepositoryBase<OMDBSearchMedia>
    {
        Task<List<OMDBSearchMediaResponse>> GetOMDBSearch(string SearchQuery);
    }
}
