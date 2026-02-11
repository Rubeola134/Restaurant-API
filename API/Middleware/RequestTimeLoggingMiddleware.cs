
using System.Diagnostics;

namespace API.Middleware
{
    public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            await next.Invoke(context);
            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds > 1000)
            {
                logger.LogWarning($"Request took {stopwatch.ElapsedMilliseconds} ms: {context.Request.Method} {context.Request.Path}");
            }
        }
    }
}