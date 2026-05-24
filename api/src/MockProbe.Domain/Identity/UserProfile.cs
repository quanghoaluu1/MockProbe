using MockProbe.Domain.Common;

namespace MockProbe.Domain.Identity;

public sealed class UserProfile : AuditableEntity
{
    public Guid UserId { get; set; }

    public string? DisplayName { get; set; }

    public string? Bio { get; set; }

    public string? TargetRole { get; set; }

    public string? ExperienceLevel { get; set; }

    public string? PreferredLanguage { get; set; }

    public string[] Skills { get; set; } = [];

    public string? Settings { get; set; }
}
