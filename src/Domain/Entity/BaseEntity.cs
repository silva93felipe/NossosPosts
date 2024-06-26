namespace Domain.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public bool Ativo { get; protected set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime AtualizadoEm { get; protected set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            Ativo = true;
            CriadoEm = DateTime.Now;
            AtualizadoEm = DateTime.Now;
        }
    }
}