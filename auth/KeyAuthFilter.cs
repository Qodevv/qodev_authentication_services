using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace qodev_authentication_services.auth;

public class KeyAuthFilter : IAuthorizationFilter
{
    private readonly IConfiguration _configuration;

    public KeyAuthFilter(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(Constant.ApiKeyHeaderName, out var extractedKey))
        {
            context.Result = new UnauthorizedObjectResult("API Key Missing");
            return;
        }

        var key = _configuration.GetValue<string>(Constant.ApiKeySectionName);
        if (!key.Equals(extractedKey))
        {
            context.Result = new UnauthorizedObjectResult("Invalid API Key");
            return;
        }
    }
}