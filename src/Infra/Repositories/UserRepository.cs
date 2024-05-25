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

        public async Task Create(User newUser)
        {
            await _context.User.AddAsync(newUser);
            await Save();
        }

        public async Task<User> GetById(Guid userId)
            => await _context.User.FirstOrDefaultAsync(e => e.Id == userId);

        public async Task Save()
            => await _context.SaveChangesAsync();
    }
}