using H6_API.Domain.DTO;

namespace H6_API.Domain.Interfaces.Repositories
{
    public interface IOMDBSearchMediaRepository :IRepositoryBase<OMDBSearchMedia>
    {
        Task<List<OMDBSearchMediaResponse>> GetOMDBSearch(string SearchQuery);
    }
}
