using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;

namespace MockProbe.Domain.Ai;

public sealed class ModelRun : AuditableEntity
{
    public Guid? PracticeSessionId { get; set; }

    public Guid? PromptTemplateId { get; set; }

    public AiProvider Provider { get; set; } = AiProvider.Unknown;

    public string ModelName { get; set; } = string.Empty;

    public ModelRunStatus Status { get; set; } = ModelRunStatus.Pending;

    public string? RequestPayload { get; set; }

    public string? ResponsePayload { get; set; }

    public string? ErrorMessage { get; set; }

    public int? PromptTokens { get; set; }

    public int? CompletionTokens { get; set; }

    public DateTimeOffset? StartedAt { get; set; }

    public DateTimeOffset? CompletedAt { get; set; }
}
