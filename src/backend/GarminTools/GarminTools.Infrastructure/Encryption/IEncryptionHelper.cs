namespace GarminTools.Infrastructure.Encryption;

public interface IEncryptionHelper
{
    string Decrypt(string encrypted);
}