using Diiage.Eval.Back.Domain.Entities.Applications;
using Diiage.Eval.Back.Domain.Entities.Passwords;
using Diiage.Eval.Back.Domain.Enums;
using Diiage.Eval.Back.Domain.Models.Passwords;
using Mapster;

namespace Diiage.Eval.Back.Domain.Models.Applications;

public abstract class ApplicationBl : IRegister
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ApplicationType ApplicationType { get; set; }
    public List<PasswordBl> Passwords { get; set; }
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ApplicationBl, ApplicationDao>()
            .Include<ApplicationProfessionalBl, ApplicationProfessionalDao>()
            .Include<ApplicationPublicBl, ApplicationPublicDao>();
    }
}