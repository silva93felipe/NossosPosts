namespace Domain.Entity
{
    public class Curtida : BaseEntity
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public Curtida(Guid postId, Guid userId) : base() 
        {
            PostId = postId;
            UserId = userId;
        }
    }
}