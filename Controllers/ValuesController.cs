using MCPWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCPWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            // Get the current context
            //var context = ModelContext.Current;

            // Access your custom context
            var userContext = ModelContext.Get<UserContext>();

            if (!userContext.Roles.Contains("ProductReader"))
            {
                return Unauthorized();
            }

            // Simulate getting products for the user
            var products = GetProductsForUser(userContext.UserId);

            return Ok(products);
        }

        private List<string> GetProductsForUser(int userId)
        {
            // No need to pass userId - we can access it from context
            var context = ModelContext.Current;
            var userContext = ModelContext.Get<UserContext>();

            // In a real app, this would query a database
            return new List<string>
        {
            $"Product1 for {userContext.UserName}",
            $"Product2 for {userContext.UserName}"
        };
        }
    }
}
