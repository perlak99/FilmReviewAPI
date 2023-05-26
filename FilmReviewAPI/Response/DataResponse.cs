namespace FilmReviewAPI.Response
{
    public class DataResponse<T> : BaseResponse
    {
        public T Data { get; set; }

        public DataResponse(T data, int statusCode, string message) : base(statusCode, message)
        {
            Data = data;
        }
    }
}
