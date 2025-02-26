using System.Security.Cryptography;
using System.Text;
using Diiage.Eval.Back.Application.Contracts.Strategies;

namespace Diiage.Eval.Back.Domain.Strategies;

public class RsaEncryptionStrategy : IEncryptionStrategy
{
    public string Encrypt(string plainText)
    {
        using var rsa = RSA.Create(2048);
        var publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
        var privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
        
        rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);

        var plainBytes = Encoding.UTF8.GetBytes(plainText);
        var encryptedBytes = rsa.Encrypt(plainBytes, RSAEncryptionPadding.OaepSHA256);
        return Convert.ToBase64String(encryptedBytes);
    }
}