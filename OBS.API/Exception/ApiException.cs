namespace OBS.API.Exception
{
    public class ApiException : System.Exception
    {
        public ApiException()
        {
        }

        public ApiException(string message)
            : base(message)
        {
        }

        public ApiException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}