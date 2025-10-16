namespace wizard_of_auth.Application.IdentityConnector;

public class ConnectorHealthStatus
{
    public bool IsHealthy { get; init; }
    public DateTime LastChecked { get; init; }
    public string? ErrorMessage { get; init; }
    public TimeSpan? ResponseTime { get; init; }
    public Dictionary<string, object>? AdditionalInfo { get; init; }
}