using Diiage.Eval.Back.Domain.Enums;

namespace Diiage.Eval.Back.Api.Models.Requests;

public class CreateApplicationRequest
{
    public string Name { get; set; } = string.Empty;
    public ApplicationType ApplicationType { get; set; }
}