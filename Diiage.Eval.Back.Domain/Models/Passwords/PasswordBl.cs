namespace Diiage.Eval.Back.Domain.Models.Passwords;

public class PasswordBl
{
    public int Id { get; set; }
    public string AccountName { get; set; } = String.Empty;
    public string EncryptedPassword { get; set; } = string.Empty;
    public string IV { get; set; } = string.Empty;
    public int ApplicationId { get; set; }
}