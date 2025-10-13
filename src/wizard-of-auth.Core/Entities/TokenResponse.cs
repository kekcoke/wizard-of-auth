using System.Text.Json.Serialization;

namespace wizard_of_auth.Core.Entities;

public class TokenResponse
{
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; set; }

    [JsonPropertyName("token_type")]
    public required string TokenType { get; set; }

    [JsonPropertyName("expires_in")]
    public required int ExpiresIn { get; set; }

    [JsonPropertyName("refresh_token")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] // Make it optional in serialization
    public string? RefreshToken { get; set; }

    [JsonPropertyName("scope")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? Scope { get; set; }
    
    [JsonPropertyName("id_token")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? IdToken { get; set; }
    
    [JsonPropertyName("issued_token_type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? IssuedTokenType { get; set; }
}