namespace wizard_of_auth.Core.Exceptions;

public class AuthenticationException : Exception
{
    public AuthenticationException() : base("Authentication failed.") { }

    public AuthenticationException(string message) : base(message) { }

    public AuthenticationException(string message, Exception innerException)
        : base(message, innerException) { }
}