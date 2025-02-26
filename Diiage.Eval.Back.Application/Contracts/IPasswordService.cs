using Diiage.Eval.Back.Domain.Models.Passwords;

namespace Diiage.Eval.Back.Application.Contracts;

public interface IPasswordService
{
    Task<List<PasswordBl>> GetPasswords(CancellationToken cancellationToken = default);
    Task DeletePassword(int id, CancellationToken cancellationToken = default);
    Task<PasswordBl> CreatePassword(string accountName, string password, int applicationId, CancellationToken cancellationToken = default);
}