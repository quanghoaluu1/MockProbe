using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;

namespace MockProbe.Domain.Interview;

public sealed class UserAnswer : AuditableEntity
{
    public Guid PracticeSessionId { get; set; }

    public Guid SessionQuestionId { get; set; }

    public string AnswerText { get; set; } = string.Empty;

    public UserAnswerStatus Status { get; set; } = UserAnswerStatus.Draft;

    public DateTimeOffset? SubmittedAt { get; set; }
}
