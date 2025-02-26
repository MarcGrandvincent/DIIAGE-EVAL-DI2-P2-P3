using Diiage.Eval.Back.Application.Contracts;
using Diiage.Eval.Back.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Diiage.Eval.Back.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IApplicationService, ApplicationService>();
        services.AddTransient<IPasswordService, PasswordService>();
        
        return services;
    }
}