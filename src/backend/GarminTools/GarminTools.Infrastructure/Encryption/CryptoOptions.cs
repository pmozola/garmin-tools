namespace GarminTools.Infrastructure.Encryption;

public class CryptoOptions
{
    public const string SectionName = "Crypto";
    public required string PrivateKey { get; set; }
}