using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApplication4.Exceptions;

namespace WebApplication4.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
     
            try
            {
                await next.Invoke(context);
            }

            catch(NotFoundException e)
            {
                context.Response.StatusCode = 404;
              await  context.Response.WriteAsync(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 500;
               await context.Response.WriteAsync("Somethingt went wrong");
            }
        }
    }
}
