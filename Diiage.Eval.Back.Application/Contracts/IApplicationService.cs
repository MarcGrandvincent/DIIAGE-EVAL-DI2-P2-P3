using Diiage.Eval.Back.Domain.Entities.Applications;
using Diiage.Eval.Back.Domain.Enums;

namespace Diiage.Eval.Back.Application.Contracts;

public interface IApplicationService
{
    Task<ApplicationDao> GetApplicationByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ApplicationDao> CreateApplicationAsync(string name, ApplicationType type, CancellationToken cancellationToken = default);
    Task<List<ApplicationDao>> GetApplicationsAsync(CancellationToken cancellationToken = default);
}