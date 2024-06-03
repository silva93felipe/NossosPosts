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

        public void Atualizar(Post post){
            _context.Post.Update(post);    
            Save();       
        }

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

        // TODO - Como fazer uma consulta que traga os posts e curtidas, favorito, comentarios ativos

        /* (   e.Curtidas.Any(c => c.Ativo)
            || e.Favoritos.Any(c => c.Ativo)
            || e.Comentarios.Any(c => c.Ativo) 
        ) */
        
        public async Task<List<Post>> GetAll()
            => await _context.Post
                             .Include(e => e.Curtidas)
                             .Include(e => e.Comentarios)
                             .Include(e => e.Favoritos)
                             .Where(e => e.Ativo)
                             .OrderByDescending(e => e.CriadoEm)
                             .ToListAsync();

        public async Task<Post> GetById(Guid postId)
            => await _context.Post
                             .Include(e => e.Comentarios)
                             .Include(e => e.Favoritos)
                             .Include(e => e.Curtidas)
                             .Where(e => e.Id == postId && e.Ativo)
                             .FirstOrDefaultAsync();

        public async Task AddCurtida(List<Curtida> curtidas){
            await _context.Curtida.AddRangeAsync(curtidas);
            await Save();
        }

        public async Task RemoveCurtida(Curtida curtida)
        {
           _context.Curtida.Update(curtida);
           await Save();
        }

        public async Task AddFavorito(List<Favorito> favoritos){
            _context.Favorito.UpdateRange(favoritos);
            await Save();
        }

        public async Task RemoveFavorito(Favorito favorito){
            _context.Favorito.Update(favorito);
            await Save();
        }

        public async Task AddComentario(List<Comentario> comentarios){
            await _context.Comentario.AddRangeAsync(comentarios);
            await Save();
        }

        public async Task RemoveComentario(Comentario comentario){
            _context.Comentario.Remove(comentario);
            await Save();
        }

        public async Task<Comentario> GetComentarioById(Guid comentarioId) 
            => await _context.Comentario.FirstOrDefaultAsync(e => e.Id == comentarioId);

        public Task Save()
            => _context.SaveChangesAsync();
    }
}