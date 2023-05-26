namespace FilmReviewAPI.Response
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public BaseResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
