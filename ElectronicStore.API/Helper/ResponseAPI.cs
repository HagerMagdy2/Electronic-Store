namespace ElectronicStore.API.Helper
{
    public class ResponseAPI
    {
        public ResponseAPI(int statusCode, string? message=null)
        {
            StatusCode = statusCode;
            Message = message?? GetMessageFromStatusCode(StatusCode); // meaning if it null get the value from StatusCode 
        }
        private string GetMessageFromStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "OK",
                400 => "Bad Request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => null
            };
        }

        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
