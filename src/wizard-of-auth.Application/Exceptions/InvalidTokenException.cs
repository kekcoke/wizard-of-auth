namespace wizard_of_auth.Application.Exceptions;

public class InvalidTokenException : Exception
{
    public InvalidTokenException() : base("The provided token is invalid or expired.") { }

    public InvalidTokenException(string message) : base(message) { }

    public InvalidTokenException(string message, Exception innerException)
        : base(message, innerException) { }
}