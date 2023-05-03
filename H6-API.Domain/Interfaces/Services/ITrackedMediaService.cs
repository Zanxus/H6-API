using H6_API.Domain.Entites;

namespace H6_API.Domain.Interfaces.Services
{
    public interface ITrackedMediaService
    {
        Task<IReadOnlyList<TrackedMedia>> GetAllByUserIdAsync(string userId);
        Task<TrackedMedia?> GetByImdbIdAsync(string imdbId);
        Task<int> GetCountByStateAsync(TrackedState state);

        IReadOnlyList<TrackedMedia> GetAll();
        TrackedMedia? Get(int id);
        void Post(TrackedMedia trackedMedia);
        void Put(TrackedMedia trackedMedia);
        void Delete(TrackedMedia trackedMedia);
    }
}
