namespace Diiage.Eval.Back.Api.Configurations.Installers;

public class CorsServiceInstaller : IServiceInstaller, IApplicationInstaller
{
    private const string CorsPolicyName = "AllowConfiguredOrigins";
    
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var allowedOrigins = new string[]
        {
            "http://10.4.205.20",
            "http://localhost:4200",
            "http://localhost:7209",
            "http://10.4.205.100:7209",
            "http://192.214.203.198:8080",
        };
        
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicyName,
                corsPolicyBuilder =>
                {
                    corsPolicyBuilder
                        .WithOrigins(allowedOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });
    }

    public void Setup(WebApplication app, IConfiguration configuration)
    {
        app.UseCors(CorsPolicyName);
    }
}