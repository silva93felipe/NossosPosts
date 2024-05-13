using Domain.Entity;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetById(Guid userId);
        public Task Create(User newUser);
        public Task Save();
    }
}