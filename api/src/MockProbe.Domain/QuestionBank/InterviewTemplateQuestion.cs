using MockProbe.Domain.Common;

namespace MockProbe.Domain.QuestionBank;

public sealed class InterviewTemplateQuestion : AuditableEntity
{
    public Guid InterviewTemplateId { get; set; }

    public Guid QuestionId { get; set; }

    public int Position { get; set; }

    public bool IsRequired { get; set; } = true;
}
