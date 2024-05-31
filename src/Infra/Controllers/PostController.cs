using Application.UseCase;
using Domain.Repositories;
using Infra.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Infra.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly CreatePost _createPostUseCase;
        private readonly GetPosts _getPostsUseCase;
        private readonly CurtirPost _curtirPost;
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        public PostController(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _createPostUseCase = new CreatePost(_userRepository, _postRepository);
            _getPostsUseCase = new GetPosts(_postRepository);
            _curtirPost = new CurtirPost(_userRepository, _postRepository);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _getPostsUseCase.Execute());
        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostDto post) {
            try
            {
                await _createPostUseCase.Execute(post.UserId, post.Titulo, post.Imagem, post.Descricao);
                return Ok(new { message = "Post criando com sucesso." });
            }
            catch (Exception err)
            {
                return BadRequest(new { message = err.Message });       
            }
        }

        [HttpPost("Curtir/{postId}")]
        public async Task<IActionResult> CurtirPost(Guid postId, [FromBody]Guid userId) {
            try
            {
                await _curtirPost.Execute( postId, userId);
                return Ok(new { message = "Post curtido" });
            }
            catch (Exception err)
            {
                return BadRequest(new { message = err.Message });       
            }
        }
    }
}