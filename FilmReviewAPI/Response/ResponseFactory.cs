namespace FilmReviewAPI.Response
{
    public static class ResponseFactory
    {
        public static DataResponse<T> CreateSuccessResponse<T>(T data)
        {
            return new DataResponse<T>(data, 200, string.Empty);
        }

        public static BaseResponse CreateSuccessResponse()
        {
            return new BaseResponse(200, string.Empty);
        }

        public static BaseResponse CreateErrorResponse(int statusCode, string message)
        {
            return new BaseResponse(statusCode, message);
        }
    }
}
