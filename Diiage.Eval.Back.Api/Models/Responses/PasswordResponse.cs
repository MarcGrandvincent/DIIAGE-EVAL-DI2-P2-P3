namespace Diiage.Eval.Back.Api.Models.Responses;

public class PasswordResponse
{
    public int Id { get; set; }
    public string EncryptedPassword { get; set; } = string.Empty;
    public string IV { get; set; } = string.Empty;
    public int ApplicationId { get; set; }
    public string AccountName { get; set; } = string.Empty;
}