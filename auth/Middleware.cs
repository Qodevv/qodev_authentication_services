namespace qodev_authentication_services.auth;

public class Middleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public Middleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(Constant.ApiKeyHeaderName, out var extractedKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API Key Missing");
            return;
        }

        var key = _configuration.GetValue<string>(Constant.ApiKeySectionName);
        if (!key.Equals(extractedKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid API Key");
            return;
        }

        await _next(context);
    }
}