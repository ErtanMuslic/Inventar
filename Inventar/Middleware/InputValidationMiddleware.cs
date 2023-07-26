using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Inventar.User.DTOs;

namespace API.Middleware
{
    public class InputValidationMiddleware
    {
        private readonly RequestDelegate _next;
        public InputValidationMiddleware(RequestDelegate next)
        {
                    _next = next;

        }
     
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == "POST" &&
                (context.Request.Path.StartsWithSegments("/api/Auth/register") ||
                 context.Request.Path.StartsWithSegments("/api/Auth/login")))
            {
                var userCredentials = await JsonSerializer.DeserializeAsync<UserDto>(context.Request.Body);

                if (userCredentials == null ||
                    string.IsNullOrEmpty(userCredentials.Username) ||
                    string.IsNullOrEmpty(userCredentials.Password))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid request body");
                    return;
                }


                string username = context.Request.Form["username"];
                string password = context.Request.Form["password"];

                if (!IsValidUsername(username) || !IsValidPassword(password))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid username or password");
                    return;
                }

                await _next(context);

            }
        }

        private bool IsValidUsername(string username)
        {
            string pattern = "^[a-zA-Z0-9]{4,20}$";
            return Regex.IsMatch(username, pattern);
           
        }

        private bool IsValidPassword(string password)
        {
            string pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$";
            return Regex.IsMatch(password, pattern);
        }


    }
}
