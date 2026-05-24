using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;

namespace MockProbe.Domain.Identity;

public sealed class User : AuditableEntity
{
    public string? Email { get; set; }

    public string Username { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public AuthProvider AuthProvider { get; set; } = AuthProvider.Local;

    public UserRole Role { get; set; } = UserRole.User;

    public UserStatus Status { get; set; } = UserStatus.Active;

    public bool IsSystemUser { get; set; }

    public string? PasswordHash { get; set; }

    public string? ExternalSubject { get; set; }

    public DateTimeOffset? LastLoginAt { get; set; }

    public string? Settings { get; set; }
}
