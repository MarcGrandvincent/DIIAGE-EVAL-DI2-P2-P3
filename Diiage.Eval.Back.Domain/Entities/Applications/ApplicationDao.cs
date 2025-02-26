using Diiage.Eval.Back.Domain.Entities.Passwords;
using Diiage.Eval.Back.Domain.Enums;
using Diiage.Eval.Back.Domain.Models.Applications;
using Mapster;

namespace Diiage.Eval.Back.Domain.Entities.Applications;

public abstract class ApplicationDao : IRegister
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ApplicationType ApplicationType { get; set; }
    public List<PasswordDao> Passwords { get; set; }
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ApplicationDao, ApplicationBl>()
            .Include<ApplicationProfessionalDao, ApplicationProfessionalBl>()
            .Include<ApplicationPublicDao, ApplicationPublicBl>();
    }
}