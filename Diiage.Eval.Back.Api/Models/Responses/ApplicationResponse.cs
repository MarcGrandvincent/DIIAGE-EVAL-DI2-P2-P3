using Diiage.Eval.Back.Domain.Enums;

namespace Diiage.Eval.Back.Api.Models.Responses;

public class ApplicationResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ApplicationType ApplicationType { get; set; }
}