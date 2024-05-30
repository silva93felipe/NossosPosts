using Application.Expection;
using Domain.Entity;
using Domain.Repositories;

namespace Application.UseCase
{
    public class CreatePost
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        public CreatePost(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task Execute(Guid userId, string titulo, string imagem, string descricao){
            User user = await _userRepository.GetById(userId);
            if(user == null) throw new UserNotFoundException("User not found!");
            Post newPost = new(userId, titulo, imagem, descricao);
            await _postRepository.Create(newPost);
        }
    }
}