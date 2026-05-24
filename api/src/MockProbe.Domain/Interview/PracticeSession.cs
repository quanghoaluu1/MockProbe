using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;
using MockProbe.Domain.Identity;

namespace MockProbe.Domain.Interview;

public sealed class PracticeSession : AuditableEntity
{
    public Guid UserId { get; set; } = DefaultLocalUser.Id;

    public Guid? ResumeId { get; set; }

    public Guid? JobDescriptionId { get; set; }

    public Guid? InterviewTemplateId { get; set; }

    public string Title { get; set; } = string.Empty;

    public PracticeSessionStatus Status { get; set; } = PracticeSessionStatus.Draft;

    public string? ShareToken { get; set; }

    public string? Settings { get; set; }

    public DateTimeOffset? StartedAt { get; set; }

    public DateTimeOffset? CompletedAt { get; set; }
}
