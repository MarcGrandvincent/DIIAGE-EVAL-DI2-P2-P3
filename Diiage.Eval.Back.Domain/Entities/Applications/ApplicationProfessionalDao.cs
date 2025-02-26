using Diiage.Eval.Back.Application.Contracts.Strategies;
using Diiage.Eval.Back.Domain.Enums;
using Diiage.Eval.Back.Domain.Strategies;

namespace Diiage.Eval.Back.Domain.Entities.Applications;

public class ApplicationProfessionalDao : ApplicationDao
{
    protected override IEncryptionStrategy GetStrategy()
    {
        return new RsaEncryptionStrategy();
    }
}