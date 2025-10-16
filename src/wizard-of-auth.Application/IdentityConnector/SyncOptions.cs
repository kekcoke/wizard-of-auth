namespace wizard_of_auth.Application.IdentityConnector;

public class SyncOptions
{
    public bool FullSync { get; init; } = false;
    public DateTime? SyncSince { get; init; }
    public bool DeleteRemovedUsers { get; init; } = false;
    public int BatchSize { get; init; } = 100;
}
