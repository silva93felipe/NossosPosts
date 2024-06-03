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
        private readonly FavoritarPost _favoritarPost;
        private readonly ComentarPost _comentarPost;
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        public PostController(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _createPostUseCase = new CreatePost(_userRepository, _postRepository);
            _getPostsUseCase = new GetPosts(_postRepository);
            _curtirPost = new CurtirPost(_userRepository, _postRepository);
            _favoritarPost = new FavoritarPost(_postRepository, _userRepository);
            _comentarPost = new ComentarPost(_userRepository, _postRepository);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _getPostsUseCase.Execute());
        [HttpPost]
        public async Task<IActionResult> Create(CreatePostDto post) {
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
        public async Task<IActionResult> Curtir(Guid postId, [FromBody]Guid userId) {
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

        [HttpPost("Favoritar/{postId}")]
        public async Task<IActionResult> Favoritar(Guid postId, [FromBody]Guid userId) {
            try
            {
                await _favoritarPost.Execute( postId, userId);
                return Ok(new { message = "Post favoritado" });
            }
            catch (Exception err)
            {
                return BadRequest(new { message = err.Message });       
            }
        }

        [HttpPost("Comentar/{postId}")]
        public async Task<IActionResult> Comentar(Guid postId, [FromBody]ComentarPostDto comentario) {
            try
            {
                await _comentarPost.Execute( postId, comentario.UserId, comentario.Texto);
                return Ok(new { message = "Comentário adicionado" });
            }
            catch (Exception err)
            {
                return BadRequest(new { message = err.Message });       
            }
        }
    }
}