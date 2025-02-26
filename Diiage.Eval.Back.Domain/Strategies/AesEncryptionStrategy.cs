using System.Security.Cryptography;
using System.Text;
using Diiage.Eval.Back.Application.Contracts.Strategies;

namespace Diiage.Eval.Back.Domain.Strategies;

public class AesEncryptionStrategy : IEncryptionStrategy
{
    private const string AesKey = "YWJjZGVmZ2hpamtsbW5vcHFyc3R1d3h5";
    
    public string Encrypt(string plainText)
    {
        using var aes = Aes.Create();
        aes.Key = Convert.FromBase64String(AesKey);
        aes.GenerateIV();

        using var encryptor = aes.CreateEncryptor();
        var plainBytes = Encoding.UTF8.GetBytes(plainText);
        var encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

        return Convert.ToBase64String(aes.IV) + ":" + Convert.ToBase64String(encryptedBytes);
    }
}