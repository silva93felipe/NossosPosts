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

        public void Atualizar(Post post) =>
            _context.Post.Update(post);           

        public async Task Create(Post newPost){
            await _context.Post.AddAsync(newPost);
            await Save();
        }
        
        public async Task<List<Post>> GetAll()
            => await _context.Post
                             .Include(e => e.Curtidas)
                             .Include(e => e.Comentarios)
                             .Include(e => e.Favoritos)
                             .Where(e => e.Ativo)
                             .OrderByDescending(e => e.CriadoEm)
                             .ThenByDescending(e => e.Comentarios.Select(e => e.CriadoEm))
                             .ToListAsync();

        public async Task<Post> GetById(Guid postId)
            => await _context.Post.Where(e => e.Id == postId && e.Ativo).FirstOrDefaultAsync();

        public Task Save()
            => _context.SaveChangesAsync();        
    }
}