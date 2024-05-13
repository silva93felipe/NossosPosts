namespace Domain.Entity
{
    public class Post : BaseEntity
    {
        public Guid UserId { get; private set; }
        public List<Comentario> Comentarios{ get; private set; }
        public List<Curtida> Curtidas { get; private set; }
        //public List<Favorito> Favoritos { get; private set; }
        public Post(Guid userId) : base()
        {
            UserId = userId;
            Comentarios = [];
            Curtidas = [];
        }

        public void AdicionarComentario(Guid userId, string texto){
            Comentarios.Add(new Comentario(texto, Id, userId));
        }
        public void Curtir(Guid userId){
            Curtidas.Add(new Curtida(Id, userId));
        }
    }
}