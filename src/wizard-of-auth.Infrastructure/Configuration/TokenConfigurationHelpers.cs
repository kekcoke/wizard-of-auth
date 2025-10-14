using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace wizard_of_auth.Infrastructure.Configuration;

// Helper ValueConverter for Scopes (Shared by both configurations)
internal static class TokenConfigurationHelpers
{
    // Converts IReadOnlyList<string> to a semicolon-delimited string for storage
    public static readonly ValueConverter<IReadOnlyList<string>, string> ScopesConverter = new(
        v => string.Join(';', v),
        v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList().AsReadOnly()
    );
}