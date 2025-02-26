using Diiage.Eval.Back.Application.Contracts.Strategies;
using Diiage.Eval.Back.Domain.Entities.Passwords;
using Diiage.Eval.Back.Domain.Enums;
using Mapster;

namespace Diiage.Eval.Back.Domain.Entities.Applications;

public abstract class ApplicationDao
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ApplicationType ApplicationType { get; set; }
    public List<PasswordDao> Passwords { get; set; } = [];

    protected abstract IEncryptionStrategy GetStrategy();

    public string Encrypt(string data)
    {
        var strategy = GetStrategy();
        return strategy.Encrypt(data);
    }
}