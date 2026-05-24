using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;

namespace MockProbe.Domain.Ai;

public sealed class AnswerEvaluationScore : AuditableEntity
{
    public Guid AnswerEvaluationId { get; set; }

    public EvaluationScoreType Type { get; set; }

    public decimal Score { get; set; }

    public decimal MaxScore { get; set; } = 10;

    public string? Rationale { get; set; }
}
