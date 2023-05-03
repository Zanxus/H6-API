using H6_API.Domain.DTO;

namespace H6_API.Domain.Interfaces.Services
{
    public interface IOMDBService
    {
        Task<List<OMDBSearchMediaResponse>?> SearchMedia(string searchQuery);
    }
}
