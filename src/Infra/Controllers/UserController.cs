using Application.UseCase;
using Domain.Repositories;
using Infra.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Infra.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly CreateUser _createUser;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _createUser = new CreateUser(_userRepository);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto user ){
            try
            {
                await _createUser.Execute(user.Email, user.Senha);
                return Ok( new { message = "Cadastrado com sucesso" } );
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}