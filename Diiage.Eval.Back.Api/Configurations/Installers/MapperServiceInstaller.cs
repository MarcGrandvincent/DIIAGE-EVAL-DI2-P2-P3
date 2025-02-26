using Mapster;
using MapsterMapper;

namespace Diiage.Eval.Back.Api.Configurations.Installers;

public class MapperServiceInstaller : IServiceInstaller
{
    /// <inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var config = new TypeAdapterConfig();
        config.Default.AddDestinationTransform(DestinationTransform.EmptyCollectionIfNull);
        services.AddSingleton(config);
        services.AddScoped<IMapper, Mapper>();
    }
}