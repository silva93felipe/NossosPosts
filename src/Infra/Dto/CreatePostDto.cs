namespace Infra.Dto
{
    public class CreatePostDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Imagem { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}