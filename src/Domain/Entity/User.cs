namespace Domain.Entity
{   
    public class User : BaseEntity
    {
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public User(string email, string senha)
        {   
            Email = email;
            Senha = senha;

        }
    }
}