using System.Security;

namespace wizard_of_auth.Core.ValueObjects;

/// <summary>
/// Secure password wrapper to prevent accidental logging/serialization
/// </summary>
public sealed class SecurePassword : IDisposable
{
    private readonly SecureString _secureString;
    
    public SecurePassword(string password)
    {
        _secureString = new SecureString();
        foreach (char c in password)
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