
using Diiage.Eval.Back.Domain.Enums;
using Diiage.Eval.Back.Domain.Models.Applications;

namespace Diiage.Eval.Back.Application.Contracts;

public interface IApplicationService
{
    Task<ApplicationBl> CreateApplicationAsync(string name, ApplicationType type, CancellationToken cancellationToken = default);
    Task<List<ApplicationBl>> GetApplicationsAsync(CancellationToken cancellationToken = default);
}