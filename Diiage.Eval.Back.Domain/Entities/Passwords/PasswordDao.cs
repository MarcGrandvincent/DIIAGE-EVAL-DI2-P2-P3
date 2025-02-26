using Diiage.Eval.Back.Domain.Entities.Applications;

namespace Diiage.Eval.Back.Domain.Entities.Passwords;

public class PasswordDao
{
    public int Id { get; set; }
    public string EncryptedPassword { get; set; } = string.Empty;
    public string IV { get; set; } = string.Empty;
    public int ApplicationId { get; set; }
    public ApplicationDao Application { get; set; }
}