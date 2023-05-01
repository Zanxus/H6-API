using H6_API.Domain.Entites;
using H6_API.Domain.Interfaces.Repositories;
using H6_API.Domain.Interfaces.Services;

namespace H6_API.Application.Services
{
    public class TrackedMediaService : ITrackedMediaService
    {
        private readonly ITrackedMediaRepository _repository;

        public TrackedMediaService(ITrackedMediaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<TrackedMedia>> GetAllByUserIdAsync(string userId)
        {
            return await _repository.GetAllByUserIdAsync(userId);
        }

        public async Task<TrackedMedia?> GetByImdbIdAsync(string imdbId)
        {
            return await _repository.GetByImdbIdAsync(imdbId);
        }

        public async Task<int> GetCountByStateAsync(TrackedState state)
        {
            return await _repository.GetCountByStateAsync(state);
        }

        // Implement any additional methods specific to TrackedMediaService here
    }
}
