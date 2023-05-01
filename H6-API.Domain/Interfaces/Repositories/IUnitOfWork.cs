namespace H6_API.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        ITrackedMediaRepository TrackedMediaRepository { get; }
        IOMDBSearchMediaRepository SearchMediaRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
