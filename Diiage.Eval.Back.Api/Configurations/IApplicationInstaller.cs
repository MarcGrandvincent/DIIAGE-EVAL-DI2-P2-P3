namespace Diiage.Eval.Back.Api.Configurations;

public interface IApplicationInstaller
{
    void Setup(WebApplication application, IConfiguration configuration);
}