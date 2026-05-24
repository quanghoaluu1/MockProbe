using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;
using MockProbe.Domain.Identity;

namespace MockProbe.Domain.QuestionBank;

public sealed class InterviewTemplate : AuditableEntity
{
    public Guid CreatedByUserId { get; set; } = DefaultLocalUser.Id;

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? TargetRole { get; set; }

    public QuestionDifficulty? Difficulty { get; set; }

    public TemplateStatus Status { get; set; } = TemplateStatus.Draft;

    public bool IsPublic { get; set; }

    public string? Settings { get; set; }
}
