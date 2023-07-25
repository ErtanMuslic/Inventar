using System;
using System.Net;
using System.Text.Json;


namespace API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public class ErrorResponse
        {
            public string? Message { get; set; }
            public string? ExceptionMessage { get; set; }
            public string? ExceptionType { get; set; }
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private  Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorResponse = new ErrorResponse
            {
                Message = "An error occurred while processing your request.",
                ExceptionMessage = ex.Message,
                ExceptionType = ex.GetType().FullName
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
    }

