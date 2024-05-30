using Application.Expection;
using Domain.Entity;
using Domain.Repositories;

namespace Application.UseCase
{
    public class FavoritarPost
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public FavoritarPost(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task Execute(Guid userId, Guid postId){
            User user = await _userRepository.GetById(userId);
            if (user == null) throw new UserNotFoundException("User not found");
            Post post =  await _postRepository.GetById(postId);
            if (post == null) throw new PostNotFoundException("Post not found");
            post.Favoritar(userId);
            _postRepository.Atualizar(post);
        }
    }
}