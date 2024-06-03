using Domain.Entity;

namespace Domain.Repositories
{
    public interface IPostRepository
    {
        public Task<Post> GetById(Guid postId);
        public Task<List<Post>> GetAll();
        public Task Create(Post newPost);
        public void Atualizar(Post post);
        public Task Save();
        Task AddCurtida(List<Curtida> curtidas);
        Task RemoveCurtida(Curtida curtida);
        Task AddFavorito(List<Favorito> favoritos);
        Task RemoveFavorito(Favorito favorito);
        Task AddComentario(List<Comentario> comentarios);
        Task RemoveComentario(Comentario comentario);
        Task<Comentario> GetComentarioById(Guid comentarioId);
    }
}