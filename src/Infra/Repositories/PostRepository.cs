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

         // TODO - Como ordernar os comentarios do post pela consulta, e porque essa consulta so traz o posts
         
        /* var a = (from posts in _context.Post.AsNoTracking()
                    join comentarios in _context.Comentario.AsNoTracking() on posts.Id equals comentarios.PostId
                    join curtidas in _context.Curtida.AsNoTracking() on posts.Id equals curtidas.PostId
                    join favoritos in _context.Favorito.AsNoTracking() on posts.Id equals favoritos.PostId
                    orderby comentarios.CriadoEm descending 
                    orderby posts.CriadoEm descending
                    select ( posts, comentarios, curtidas, favoritos )
            )
            .ToList(); */
        
        public async Task<List<Post>> GetAll()
            => await _context.Post
                             .Include(e => e.Curtidas)
                             .Include(e => e.Comentarios)
                             .Include(e => e.Favoritos)
                             .Where(e => e.Ativo)
                             .OrderByDescending(e => e.CriadoEm)
                             .ToListAsync();

        public async Task<Post> GetById(Guid postId)
            => await _context.Post.Where(e => e.Id == postId && e.Ativo).FirstOrDefaultAsync();

        public Task Save()
            => _context.SaveChangesAsync();        
    }
}