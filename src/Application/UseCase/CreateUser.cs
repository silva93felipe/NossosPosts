using Domain.Entity;

namespace Application.UseCase
{
    public class CreateUser
    {
        public void Execute(string email, string senha){
            // validar informações
 
            //Criando       
            User newUser = new(email, senha);

            //salvar user
        }
    }
}