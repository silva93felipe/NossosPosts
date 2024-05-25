using Domain.Entity;
using Domain.Repositories;

namespace Application.UseCase
{
    public class GetPosts
    {
        private readonly IPostRepository _postRepository;
        public GetPosts(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Task<List<Post>> Execute() => _postRepository.GetAll();
    }
}