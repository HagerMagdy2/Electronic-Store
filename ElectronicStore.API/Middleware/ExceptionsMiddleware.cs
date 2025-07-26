using ElectronicStore.API.Helper;
using System.Net;
using System.Text.Json;

namespace ElectronicStore.API.Middleware
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionsMiddleware(RequestDelegate next)
        {
           _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode=(int)HttpStatusCode.InternalServerError; // Internal Server Error
                context.Response.ContentType = "application/json";
                var response = new ApiExceptions((int)HttpStatusCode.InternalServerError,
                    ex.StackTrace,
                    ex.Message);
                var json=JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }

}
