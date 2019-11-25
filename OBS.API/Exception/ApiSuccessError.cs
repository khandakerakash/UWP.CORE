namespace OBS.API.Exception
{
    public class ApiError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }


    public class ApiSuccessResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}