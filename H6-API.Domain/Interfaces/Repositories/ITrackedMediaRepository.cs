using H6_API.Domain.Entites;

namespace H6_API.Domain.Interfaces.Repositories
{
    public interface ITrackedMediaRepository : IRepositoryBase<TrackedMedia>
    {
        Task<IReadOnlyList<TrackedMedia>> GetAllByUserIdAsync(string userId);
        Task<TrackedMedia?> GetByImdbIdAsync(string imdbId);
        Task<int> GetCountByStateAsync(TrackedState state);
        // Add any additional methods specific to TrackedMedia here
    }

}
