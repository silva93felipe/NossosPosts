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

        // TODO - Favoritar e desfavoritar são dois use cases destintos... separar
        public async Task Execute(Guid postId, Guid userId){
            User user = await _userRepository.GetById(userId);
            if (user == null) throw new UserNotFoundException("User not found");
            Post post =  await _postRepository.GetById(postId);
            if (post == null) throw new PostNotFoundException("Post not found");
            Favorito isFavorito = post.Favoritos.Find(e => e.UserId == userId);
            if(isFavorito != null){
                if(isFavorito.Ativo == false){
                    isFavorito.Ativar();
                }else{
                    isFavorito.Inativar();                    
                }
                await _postRepository.AtualizarFavorito(isFavorito);
            }else{
                post.Favoritar(userId);
                await _postRepository.AddFavoritar(post.Favoritos);
            }
        }
    }
}