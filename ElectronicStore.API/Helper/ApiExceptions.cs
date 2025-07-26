namespace ElectronicStore.API.Helper
{
    public class ApiExceptions : ResponseAPI
    {
        public ApiExceptions(int statusCode,string details=null, string? message = null) : base(statusCode, message)
        {
            Details = details;
        }
        public string Details { get; set; }
    }
}
