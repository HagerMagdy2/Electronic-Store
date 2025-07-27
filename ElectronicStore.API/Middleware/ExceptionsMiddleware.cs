using ElectronicStore.API.Helper;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Text.Json;

namespace ElectronicStore.API.Middleware
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;
        private readonly IMemoryCache _memoryCache;
        public ExceptionsMiddleware(RequestDelegate next, IHostEnvironment environment, IMemoryCache memoryCache)
        {
            _next = next;
            _environment = environment;
            _memoryCache = memoryCache;
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
        private bool IsRequestAllowed(HttpContext context) 
        {
            var ip = context.Connection.RemoteIpAddress.ToString();   
            var cachKey=$"Rate:{ip}";
            var dateNow=DateTime.Now;
            var (timestamp, count) = _memoryCache.GetOrCreate(cachKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
                return (dateNow, 0);
            });

        }
    }

}
