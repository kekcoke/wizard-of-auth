using System.Text.RegularExpressions;

namespace wizard_of_auth.Core.ValueObjects;

/// <summary>
/// Validated email address value object.
/// </summary>
public sealed record EmailAddress
{
    public string Value { get; }

    private EmailAddress(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Factory method to create EmailAddress after validation.
    /// </summary>
    /// <param name="email">Email string to validate and wrap</param>
    /// <returns>New email address instance</returns>
    /// <exception cref="ArgumentException">Thrown when the email is not valid</exception>
    public static EmailAddress Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        { 
            throw new ArgumentException("Email cannot be empty", nameof(email));
        }

        // Validate email
        if (!email.Contains("@") || !email.Contains(".") || !email.Contains("..") || email.Length > 254)
            throw new ArgumentException("Invalid email format", nameof(email));

        // Regex validation
        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        var isEmailValid = Regex.IsMatch(email, emailPattern);

        if (!isEmailValid)
            throw new ArgumentException("Invalid email format", nameof(email));
        
        return new EmailAddress(email.Trim().ToLowerInvariant());
    }
    
}
