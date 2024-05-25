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
    }
}