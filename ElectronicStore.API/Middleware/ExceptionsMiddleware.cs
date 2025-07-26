using ElectronicStore.API.Helper;
using System.Net;
using System.Text.Json;

namespace ElectronicStore.API.Middleware
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;
        public ExceptionsMiddleware(RequestDelegate next, IHostEnvironment environment)
        {
            _next = next;
            _environment = environment;
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
                var response = _environment.IsDevelopment() ?
                    new ApiExceptions((int)HttpStatusCode.InternalServerError,
                    ex.StackTrace,
                    ex.Message) : new ApiExceptions((int)HttpStatusCode.InternalServerError,
                    ex.Message);
                var json=JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }

}
