using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;

namespace MockProbe.Domain.Identity;

public sealed class GuestSession : AuditableEntity
{
    public Guid? ConvertedUserId { get; set; }

    public string SessionTokenHash { get; set; } = string.Empty;

    public GuestSessionStatus Status { get; set; } = GuestSessionStatus.Active;

    public DateTimeOffset ExpiresAt { get; set; }

    public DateTimeOffset? ConvertedAt { get; set; }
}
