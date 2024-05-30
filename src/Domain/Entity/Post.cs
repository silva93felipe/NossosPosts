namespace Domain.Entity
{
    public class Post : BaseEntity
    {
        public Guid UserId { get; private set; }
        public string Titulo { get; private set; }
        public string Imagem { get; private set; }
        public string Descricao { get; private set; }
        public List<Comentario> Comentarios{ get; private set; }
        public List<Curtida> Curtidas { get; private set; }
        public List<Favorito> Favoritos { get; private set; }
        public Post(Guid userId, string titulo, string imagem, string descricao) : base()
        {
            UserId = userId;
            Titulo = titulo;
            Imagem = imagem;
            Descricao = descricao;
            Comentarios = [];
            Curtidas = [];
            Favoritos = [];
        }

        public void Comentar(Guid userId, string texto){
            AtualizadoEm = DateTime.Now;
            Comentarios.Add(new Comentario(texto, Id, userId));
        }
        public void Curtir(Guid userId){
            AtualizadoEm = DateTime.Now;
            Curtidas.Add(new Curtida(Id, userId));
        }
         public void Favoritar(Guid userId){
            AtualizadoEm = DateTime.Now;
            Favoritos.Add(new Favorito(Id, userId));
        }
    }
}