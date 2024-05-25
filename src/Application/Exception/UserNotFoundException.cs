namespace Application.Expection
{
    class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message){}
    }
}