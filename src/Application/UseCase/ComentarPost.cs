using Application.Expection;
using Domain.Entity;
using Domain.Repositories;

namespace Application.UseCase
{
    public class ComentarPost
    {   
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        public ComentarPost(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }
        public async void Execute(Guid postId, Guid userId, string texto){
            User user = await _userRepository.GetById(userId);
            if (user == null) throw new UserNotFoundException("User not found");
            Post post =  await _postRepository.GetById(postId);
            if (post == null) throw new PostNotFoundException("Post not found");
            post.Comentar(user.Id, texto);
            await _postRepository.Save();
        }
    }
}