namespace wizard_of_auth.Core.Interfaces;

public interface ITokenService
{
    Task<string> GenerateAccessTokenAsync(Guid userId, Guid clientId, List<string> scopes);
    Task<string> GenerateRefreshTokenAsync(Guid userId, Guid clientId);
    Task<bool> ValidateTokenAsync(string token);
    Task<bool> ValidateRefreshTokenAsync(string token);
}