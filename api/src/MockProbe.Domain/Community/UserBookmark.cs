using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;
using MockProbe.Domain.Identity;

namespace MockProbe.Domain.Community;

public sealed class UserBookmark : AuditableEntity
{
    public Guid UserId { get; set; } = DefaultLocalUser.Id;

    public string EntityType { get; set; } = string.Empty;

    public Guid EntityId { get; set; }

    public string? Notes { get; set; }
}
