namespace Domain.Entity
{
   public class Comentario : BaseEntity
   {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string Texto { get; set; }
        public Comentario(string texto, Guid postId, Guid userId) : base()
        {
            Texto = texto; 
            PostId = postId;
            UserId = userId;
        }
   }
}