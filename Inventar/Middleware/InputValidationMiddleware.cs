using System.Text.RegularExpressions;

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
            if (context.Request.Path == "/api/Auth/register" && context.Request.Method == "POST")
            {
                var requestBody = await context.Request.ReadFormAsync();
                var username = requestBody["username"];
                var password = requestBody["password"];
                var email = requestBody["email"];

                if (!IsValidUsername(username) || !IsValidPassword(password) || !IsValidEmail(email))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid input.");
                    return;
                }
            }

            if (context.Request.Path == "/api/Auth/login" && context.Request.Method == "POST")
            {
                var requestBody = await context.Request.ReadFormAsync();
                var usernameOrEmail = requestBody["usernameOrEmail"];
                var password = requestBody["password"];

                if (string.IsNullOrEmpty(usernameOrEmail) || string.IsNullOrEmpty(password))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid input.");
                    return;
                }
            }

            await _next(context);
        }

        private bool IsValidUsername(string username)
        {
            // Use a regular expression to check if the username contains only alphanumeric characters
            // and is between 4 and 20 characters long.
            string pattern = "^[a-zA-Z0-9]{4,20}$";
            return Regex.IsMatch(username, pattern);
        }

        private bool IsValidPassword(string password)
        {
            // Use a regular expression to check if the password is at least 8 characters long,
            // containing at least one uppercase letter, one lowercase letter, and one digit.
            string pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        private bool IsValidEmail(string email)
        {
            // Use a regular expression to check if the email is in a valid format.
            string pattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
