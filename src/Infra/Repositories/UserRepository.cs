using Domain.Entity;
using Domain.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PostContext _context;
        public UserRepository(PostContext postContext)
        {
            _context = postContext;
        }

        public Task Create(User newUser)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(Guid userId)
            => await _context.User.FirstOrDefaultAsync(e => e.Id == userId);

        public Task Save()
            => _context.SaveChangesAsync();
    }
}