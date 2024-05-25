namespace Application.Expection
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException(string message) : base(message) {}
    }
}