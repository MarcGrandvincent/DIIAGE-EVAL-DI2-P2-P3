using Microsoft.AspNetCore.Mvc.Razor;

namespace Diiage.Eval.Back.Api.Configurations.Installers;

public class ControllerServiceInstaller : IServiceInstaller
{
    /// <inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddLocalization(options => options.ResourcesPath = "Resources");
        services.AddControllers()
            .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
            .AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddNewtonsoftJson(
                options =>
                {
                    // TODO : Later if needed
                    //options.SerializerSettings.Converters.Add(new DateTimeJsonConverter());
                    //options.SerializerSettings.Converters.Add(new TimeOnlyJsonConverter());
                });
    }
}