namespace API.Errors
{
    public class ApiException
    {
        public ApiException(int statusCode, string message = null, string details = null)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }

        public int StatusCode {get; private set;}
        public string Message {get; private set;}
        public string Details {get; private set;}
    }
}