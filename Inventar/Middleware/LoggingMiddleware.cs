using System.Diagnostics;

namespace API.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation($"Request received: {context.Request.Method}  {context.Request.Path}");

            await _next(context);
            timer.Stop();
            var timeElapsed = timer.ElapsedMilliseconds;

            _logger.LogInformation($"Request duration:{timeElapsed} ms");

            _logger.LogInformation($"Response sent: Method:{context.Request.Method}  Status code: {context.Response.StatusCode}");
 
        }
    }
}
