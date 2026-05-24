using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;

namespace MockProbe.Domain.Interview;

public sealed class SessionQuestion : AuditableEntity
{
    public Guid PracticeSessionId { get; set; }

    public Guid? QuestionId { get; set; }

    public string Prompt { get; set; } = string.Empty;

    public int Position { get; set; }

    public SessionQuestionStatus Status { get; set; } = SessionQuestionStatus.Pending;

    public DateTimeOffset? AskedAt { get; set; }

    public string? Metadata { get; set; }
}
