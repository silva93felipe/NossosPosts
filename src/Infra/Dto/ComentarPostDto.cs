namespace Infra.Dto
{
    public class ComentarPostDto
    {
        public string Texto { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}