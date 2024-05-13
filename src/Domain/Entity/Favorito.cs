namespace Domain.Entity
{
    public class Favorito : BaseEntity
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public Favorito(Guid postId, Guid userId) : base() 
        {
            PostId = postId;
            UserId = userId;
        }
    }
}