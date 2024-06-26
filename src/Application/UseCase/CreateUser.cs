using Domain.Entity;
using Domain.Repositories;

namespace Application.UseCase
{
    public class CreateUser
    {
        private readonly IUserRepository _userRepository;
        public CreateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Execute(string email, string senha){
            if(string.IsNullOrEmpty(email)) {
                throw new ArgumentNullException("email");
            }
            if(string.IsNullOrEmpty(senha)){
                throw new ArgumentNullException("senha");
            }            
            User newUser = new(email, senha);
            await _userRepository.Create(newUser);
        }
    }
}