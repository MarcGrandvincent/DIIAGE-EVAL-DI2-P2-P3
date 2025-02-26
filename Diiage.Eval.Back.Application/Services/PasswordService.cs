using Backoffice.Core.Repositories.Interfaces;
using Backoffice.Core.Repositories.Transactions;
using Diiage.Eval.Back.Application.Contracts;
using Diiage.Eval.Back.Domain.Entities.Passwords;
using Diiage.Eval.Back.Domain.Models.Passwords;
using Diiage.Eval.Back.Repositories.Interfaces;
using MapsterMapper;

namespace Diiage.Eval.Back.Application.Services;

public class PasswordService(IUnitOfWork unitOfWork, IMapper mapper) : IPasswordService
{
    private readonly IGenericRepository<PasswordDao> _passwordRepository =
        unitOfWork.GetRepository<PasswordDao>();
    public async Task<List<PasswordBl>> GetPasswords(CancellationToken cancellationToken = default)
    {
        var passwords = await _passwordRepository.GetMultipleAsync(
            predicate: null,
            orderBy: null,
            include: null,
            disableTracking: false,
            cancellationToken: cancellationToken);

        return mapper.Map<List<PasswordDao>, List<PasswordBl>>(passwords);
    }

    public async Task DeletePassword(int id, CancellationToken cancellationToken = default)
    {
        await using var tx = _passwordRepository.BeginTransaction();

        var passwords = await _passwordRepository.GetFirstOrDefaultAsync(
            predicate: p => p.Id == id,
            orderBy: null,
            include: null,
            disableTracking: false,
            cancellationToken: cancellationToken);
        
        if (passwords is not null)
            _passwordRepository.Delete(passwords);
        
        await unitOfWork.SaveAsync(cancellationToken);
        await tx.CommitAsync(cancellationToken);
    }

    public async Task<PasswordBl> CreatePassword(string password, int applicationId, CancellationToken cancellationToken = default)
    {
        await using var tx = _passwordRepository.BeginTransaction();

        // TODO : Vérifier que l'application existe et crypter le mot de passe en fonction du type de celui-ci

        var passwordDao = new PasswordDao()
        {
            EncryptedPassword = password,
            ApplicationId = applicationId,
        };
        
        _passwordRepository.Add(passwordDao);
        await unitOfWork.SaveAsync(cancellationToken);
        await tx.CommitAsync(cancellationToken);

        return mapper.Map<PasswordDao, PasswordBl>(passwordDao);
    }
}