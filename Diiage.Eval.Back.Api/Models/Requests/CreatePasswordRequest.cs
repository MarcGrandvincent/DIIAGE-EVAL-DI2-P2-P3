namespace Diiage.Eval.Back.Api.Models.Requests;

public class CreatePasswordRequest
{
    public string AccountName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int ApplicationId { get; set; }
}