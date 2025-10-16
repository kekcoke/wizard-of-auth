namespace wizard_of_auth.Application.IdentityConnector;

public class SyncResult
{
    public bool IsSuccess { get; init; }
    public int TotalUsers { get; init; }
    public int UsersAdded { get; init; }
    public int UsersUpdated { get; init; }
    public int UsersDeleted { get; init; }
    public IReadOnlyList<string> Errors { get; init; } = Array.Empty<string>();
    public DateTime SyncStarted { get; init; }
    public DateTime SyncCompleted { get; init; }
}