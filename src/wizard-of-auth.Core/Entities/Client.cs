namespace wizard_of_auth.Core.Entities;

public class Client
{
    public Guid Id { get; private set; }
    public Guid TenantId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; set; } = string.Empty;
    public List<string> AllowedScopes { get; private set; }
    public List<string> AllowedGrantTypes { get; private set; }
    public List<string> RedirectUris { get; private set; }
    public int AccessTokenLifetime { get; private set; }
    public bool RequirePkce { get; private set; }
    public bool IsDeleted { get; private set; }
    public string ClientSecret { get; private set; }
    
    public Client(Guid clientId, 
        string clientSecret, 
        string name,
        Guid tenantId)
    {
        Id = clientId;
        ClientSecret = clientSecret;
        Name = name;
        RedirectUris = new List<string>();
        AllowedScopes = new List<string>();
        AllowedGrantTypes = new List<string>();
        AccessTokenLifetime = 3600;
        RequirePkce = false;
        TenantId = tenantId;
        IsDeleted = false;
    }
    
    public static Client Create(Guid clientId,
        string name,
        Guid tenantId)
    {
        var clientSecret = GenerateSecret();
        return new Client(clientId, clientSecret, name, tenantId);
    }

    private static string GenerateSecret() => 
        Convert.ToBase64String(System.Security.Cryptography.RandomNumberGenerator.GetBytes(32));
}