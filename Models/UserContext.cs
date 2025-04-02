namespace MCPWebApi.Models
{
    // Define your custom context model
    public record UserContext(int UserId, string UserName, string[] Roles);
    //public record RequestContext(Guid CorrelationId, DateTime RequestTime);
    //public record TenantContext(int TenantId, string TenantName);
}
