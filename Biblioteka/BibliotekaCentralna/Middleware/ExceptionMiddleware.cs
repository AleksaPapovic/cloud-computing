using BibliotekaCentralna.Domain;
using Newtonsoft.Json;
using System.Net;

namespace BibliotekaCentralna.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (DomainException exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)exception.StatusCode;

                if (exception.InnerException != null)
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.InnerException.Message));
                else
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.Message));
            }
            catch (Exception exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                Console.WriteLine("trace" + exception.StackTrace);
                if (exception.InnerException != null)
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.InnerException.Message));
                else
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.Message));
            }
        }
    }
}
