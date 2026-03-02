using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace GarminTools.Infrastructure.Encryption;

public class EncryptionHelper(IOptions<CryptoOptions> options) : IEncryptionHelper
{
    private readonly RSA _privateKey = GetPrivateKeyFromPemFile(options.Value);

    public string Decrypt(string encrypted)
    {
        var data = _privateKey
            .Decrypt(Convert.FromBase64String(encrypted), RSAEncryptionPadding.Pkcs1);
        
        return Encoding.UTF8.GetString(data);
    }

    private static RSA GetPrivateKeyFromPemFile(CryptoOptions options)
    {
        var key = new PemReader(new StringReader(options.PrivateKey)).ReadObject();

        var rsaParameters =
            DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)((AsymmetricCipherKeyPair)key).Private);

        var rsa = RSA.Create();
        rsa.ImportParameters(rsaParameters);

        return rsa;
    }
}