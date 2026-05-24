using MockProbe.Domain.Enums;

namespace MockProbe.Domain.Identity;

public static class DefaultLocalUser
{
    public static readonly Guid Id = Guid.Parse("00000000-0000-0000-0000-000000000001");

    public const string Email = "local@interview-practice.local";
    public const string Username = "local";
    public const string FullName = "Local User";
    public const AuthProvider AuthProvider = Enums.AuthProvider.None;
    public const UserRole Role = UserRole.Admin;
    public const UserStatus Status = UserStatus.Active;
    public const bool IsSystemUser = true;
}
