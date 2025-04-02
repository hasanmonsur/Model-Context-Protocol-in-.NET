using MCPWebApi.Models;

namespace MCPWebApi.Middlewares
{
    public class UserContextMiddleware
    {
        private readonly RequestDelegate _next;

        public UserContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            // In a real app, you'd get this from authentication
            var userContext = new UserContext(
                UserId: 123,
                UserName: "john.doe",
                Roles: new[] { "ProductReader", "Admin" }
            );

            // Set the context for the current request
            ModelContext.Set(userContext);


            await _next(httpContext);
        }
    }
}
