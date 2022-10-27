namespace PasswordManager.Application.Contracts.Infrastructure;
public interface IEncryptionService
{
    string DecryptString( string cipherText);
    string EncryptString(string plainText);
}