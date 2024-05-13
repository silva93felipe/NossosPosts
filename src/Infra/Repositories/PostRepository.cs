using Domain.Entity;
using Domain.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly PostContext _context;
        public PostRepository(PostContext postContext)
        {
            _context = postContext;
        }

        public Task Atualizar(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Create(Post newPost)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Post>> GetAll()
            => await _context.Post.ToListAsync();

        public Task<Post> GetById(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task Save()
            => _context.SaveChangesAsync();        
    }
}