using System.Security;

namespace wizard_of_auth.Core.ValueObjects;

/// <summary>
/// Secure client secret wrapper
/// </summary>
public sealed class ClientSecret : IDisposable
{
    private readonly SecureString _secureString;
    
    public ClientSecret(string secret)
    {
        _secureString = new SecureString();
        foreach (char c in secret)
        {
            _secureString.AppendChar(c);
        }
        _secureString.MakeReadOnly();
    }
    
    public SecureString GetSecureString() => _secureString.Copy();
    
    public void Dispose()
    {
        _secureString?.Dispose();
    }
}