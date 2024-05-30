using Application.UseCase;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Infra.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly CreatePost _createPostUseCase;
        private readonly GetPosts _getPostsUseCase;
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        public PostController(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _createPostUseCase = new CreatePost(_userRepository, _postRepository);
            _getPostsUseCase = new GetPosts(_postRepository);
        }
        [HttpGet]
        [Route("ping")]
        public IActionResult Teste(){
            return Ok("Pong");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _getPostsUseCase.Execute());
    }
}