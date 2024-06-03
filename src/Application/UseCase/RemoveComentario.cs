using Application.Expection;
using Domain.Entity;
using Domain.Repositories;

namespace Application.UseCase
{
    public class RemoveComentario
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        public RemoveComentario(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task Execute(Guid comentarioId, Guid userId){
            User user = await _userRepository.GetById(userId);
            if(user == null) throw new UserNotFoundException("User not found");
            Comentario comentario = await _postRepository.GetComentarioById(comentarioId);
            if(comentario == null) throw new ComentarioNotFoundException("Comentario not found");
            if(comentario.UserId != userId) throw new ArgumentException("Not authorized");
            await _postRepository.RemoveComentario(comentario);
        }
    }
}