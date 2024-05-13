using Domain.Entity;

namespace Application.UseCase
{
    public class CreatePost
    {
        public void Execute(Guid userId){
            // Verificar se o ususário existe

            // criar Post
            Post newPost = new(userId);
            
            // Salvar
        }
    }
}