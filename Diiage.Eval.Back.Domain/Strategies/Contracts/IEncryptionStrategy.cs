namespace Diiage.Eval.Back.Application.Contracts.Strategies;

public interface IEncryptionStrategy
{
    string Encrypt(string plainText);
}