namespace Application.Expection
{
    public class ComentarioNotFoundException : Exception
    {
        public ComentarioNotFoundException(string message) : base(message){}
    }
}