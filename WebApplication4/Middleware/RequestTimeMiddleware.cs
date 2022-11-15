using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebApplication4.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;
        private Stopwatch _stopwatch;
        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _logger = logger;   
            _stopwatch = new Stopwatch();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwatch.Start();
           await next.Invoke(context);
            _stopwatch.Stop();
            var ellapsedMilisecond = _stopwatch.ElapsedMilliseconds;
            if(ellapsedMilisecond/1000 > 4)
            {
                var message = $"{context.Request.Method} at {context.Request.Path} took {ellapsedMilisecond} ms";
                _logger.LogInformation(message);
            }
        }
    }
}
