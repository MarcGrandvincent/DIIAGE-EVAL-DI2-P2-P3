
using Diiage.Eval.Back.Application.Contracts.Strategies;
using Diiage.Eval.Back.Domain.Strategies;

namespace Diiage.Eval.Back.Domain.Entities.Applications;

public class ApplicationPublicDao : ApplicationDao
{
    protected override IEncryptionStrategy GetStrategy()
    {
        return new AesEncryptionStrategy();
    }
}