using Backoffice.Core.Repositories.Interfaces;
using Backoffice.Core.Repositories.Transactions;
using Diiage.Eval.Back.Application.Contracts;
using Diiage.Eval.Back.Domain.Entities.Applications;
using Diiage.Eval.Back.Domain.Enums;
using Diiage.Eval.Back.Domain.Models.Applications;
using Diiage.Eval.Back.Repositories.Interfaces;
using MapsterMapper;

namespace Diiage.Eval.Back.Application.Services;

public class ApplicationService(IUnitOfWork unitOfWork, IMapper mapper) : IApplicationService
{
    private readonly IGenericRepository<ApplicationDao> _applicationRepository =
        unitOfWork.GetRepository<ApplicationDao>();
    
    public async Task<ApplicationBl> CreateApplicationAsync(string name, ApplicationType type, CancellationToken cancellationToken = default)
    {
        await using var tx = _applicationRepository.BeginTransaction();

        ApplicationDao application = type switch
        {
            ApplicationType.Professional => new ApplicationProfessionalDao()
            {
                Name = name, ApplicationType = ApplicationType.Professional
            },
            ApplicationType.Public => new ApplicationPublicDao()
            {
                Name = name, ApplicationType = ApplicationType.Public
            },
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };

        _applicationRepository.Add(application);
        await unitOfWork.SaveAsync(cancellationToken);
        await tx.CommitAsync(cancellationToken);

        return mapper.Map<ApplicationDao, ApplicationBl>(application);
    }

    public async Task<List<ApplicationBl>> GetApplicationsAsync(CancellationToken cancellationToken = default)
    {
        var applications = await _applicationRepository.GetMultipleAsync(
            predicate: null,
            orderBy: null,
            include: null,
            disableTracking: false,
            cancellationToken: cancellationToken);

        return mapper.Map<List<ApplicationDao>, List<ApplicationBl>>(applications);
    }
}