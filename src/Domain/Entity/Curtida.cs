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

        public void Inativar(){
            Ativo = false;
            AtualizadoEm = DateTime.Now;
        }

        public void Ativar(){
            Ativo = true;
            AtualizadoEm = DateTime.Now;
        }
    }
}