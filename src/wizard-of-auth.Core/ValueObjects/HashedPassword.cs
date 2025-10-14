using System.Security.Cryptography;
using System.Text;

namespace wizard_of_auth.Core.ValueObjects;

/// <summary>
/// Hashed password value object, preventing direct access to the raw password as string.
/// </summary>
public sealed record HashedPassword
{
    public string Value { get; }
    public string? Salt { get; }

    private HashedPassword(string value, string? salt = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Hashed password cannot be empty.", nameof(value));
        }
        
        Value = value;
        Salt = salt;
    }

    /// <summary>
    /// Creates a new HashedPassword instance from a hashed password string.
    /// </summary>
    /// <param name="hashedPassword">The hashed password string.</param>
    public static HashedPassword FromHash(string hash, string? salt = null)
        => new(hash, salt);
    
    /// <summary>
    ///  Compares another raw password after hashing.
    /// </summary>
    /// <returns>True or false</returns>
    public bool EqualsHash(string rawPassword)
    {
        if (string.IsNullOrWhiteSpace(rawPassword))
            return false;

        // Combine raw password with salt if present
        var input = Salt is not null
            ? rawPassword + Salt
            : rawPassword;

        // Recompute hash using same algorithm (SHA256 as example)
        using var sha = SHA256.Create();
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var computedHashBytes = sha.ComputeHash(inputBytes);
        var computedHash = Convert.ToHexString(computedHashBytes);

        // Compare securely
        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(Value),
            Encoding.UTF8.GetBytes(computedHash)
        );
    }
    
    public override string ToString() => "[SECRET_HASH]"; // Prevent accidental logging of the hashed password
}
