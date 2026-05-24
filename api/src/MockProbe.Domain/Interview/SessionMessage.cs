using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;

namespace MockProbe.Domain.Interview;

public sealed class SessionMessage : AuditableEntity
{
    public Guid PracticeSessionId { get; set; }

    public Guid? SessionQuestionId { get; set; }

    public MessageRole Role { get; set; }

    public int SequenceNumber { get; set; }

    public string Content { get; set; } = string.Empty;

    public string? Metadata { get; set; }
}
