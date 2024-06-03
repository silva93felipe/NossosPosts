using Application.Expection;
using Domain.Entity;
using Domain.Repositories;

namespace Application.UseCase
{
    public class CurtirPost
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        public CurtirPost(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task Execute(Guid postId, Guid userId){
            User user = await _userRepository.GetById(userId);
            if (user == null) throw new UserNotFoundException("User not found");
            Post post =  await _postRepository.GetById(postId);
            if (post == null) throw new PostNotFoundException("Post not found");
            Curtida curtida = post.Curtidas.Find(c => c.UserId == userId);
            if (curtida != null){
                if(curtida.Ativo == false){
                    curtida.Ativar();
                }else{
                    curtida.Inativar();
                }
                await _postRepository.RemoveCurtida(curtida);
            }else{
                post.Curtir(user.Id);
                await _postRepository.AddCurtida(post.Curtidas);
            }
        }
    }
}