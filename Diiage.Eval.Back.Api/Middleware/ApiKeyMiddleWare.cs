namespace Diiage.Eval.Back.Api.Middleware;

public class ApiKeyMiddleware(RequestDelegate next, ILogger<ApiKeyMiddleware> logger)
{
    private const string ApiKeyHeader = "x-api-key";

    public async Task Invoke(HttpContext context, IConfiguration configuration)
    {
        if (!context.Request.Headers.TryGetValue(ApiKeyHeader, out var extractedApiKey))
        {
            logger.LogWarning("Requête refusée : clé API manquante.");
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API Key is missing");
            return;
        }

        var apiKey = configuration["ApiSettings:ApiKey"];

        if (!apiKey.Equals(extractedApiKey))
        {
            logger.LogWarning("Requête refusée : clé API invalide.");
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        await next(context);
    }
}