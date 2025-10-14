namespace wizard_of_auth.Core.Entities;

/// <summary>
/// Generic result pattern for operations
/// </summary>
public class Result<T>
{
    public bool IsSuccess { get; init; }
    public T? Data { get; init; }
    public string? ErrorCode { get; init; }
    public string? ErrorMessage { get; init; }
    public Dictionary<string, object>? Metadata { get; init; }
    
    public static Result<T> Success(T data, Dictionary<string, object>? metadata = null) => 
        new() { IsSuccess = true, Data = data, Metadata = metadata };
    
    public static Result<T> Failure(string errorCode, string errorMessage) => 
        new() { IsSuccess = false, ErrorCode = errorCode, ErrorMessage = errorMessage };
}