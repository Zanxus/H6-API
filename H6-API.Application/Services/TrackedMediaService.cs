using H6_API.Domain.Entites;
using H6_API.Domain.Interfaces.Repositories;
using H6_API.Domain.Interfaces.Services;

namespace H6_API.Application.Services
{
    public class TrackedMediaService : ITrackedMediaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrackedMediaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<TrackedMedia>> GetAllByUserIdAsync(string userId)
        {
            return await _unitOfWork.TrackedMediaRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<TrackedMedia?> GetByImdbIdAsync(string imdbId)
        {
            return await _unitOfWork.TrackedMediaRepository.GetByImdbIdAsync(imdbId);
        }

        public async Task<int> GetCountByStateAsync(TrackedState state)
        {
            return await _unitOfWork.TrackedMediaRepository.GetCountByStateAsync(state);
        }

        void ITrackedMediaService.Delete(TrackedMedia trackedMedia)
        {
            _unitOfWork.TrackedMediaRepository.Delete(trackedMedia);
        }

        TrackedMedia? ITrackedMediaService.Get(int id)
        {
            return _unitOfWork.TrackedMediaRepository.Get(id);
        }

        IReadOnlyList<TrackedMedia> ITrackedMediaService.GetAll()
        {
            return _unitOfWork.TrackedMediaRepository.GetAll();
        }

        void ITrackedMediaService.Post(TrackedMedia trackedMedia)
        {
             _unitOfWork.TrackedMediaRepository.Add(trackedMedia);
        }

        void ITrackedMediaService.Put(TrackedMedia trackedMedia)
        {
            _unitOfWork.TrackedMediaRepository.Update(trackedMedia);
        }

        // Implement any additional methods specific to TrackedMediaService here
    }
}
