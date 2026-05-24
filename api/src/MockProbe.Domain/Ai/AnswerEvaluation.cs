using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;

namespace MockProbe.Domain.Ai;

public sealed class AnswerEvaluation : AuditableEntity
{
    public Guid UserAnswerId { get; set; }

    public Guid? ModelRunId { get; set; }

    public EvaluationStatus Status { get; set; } = EvaluationStatus.Pending;

    public decimal? OverallScore { get; set; }

    public string? Summary { get; set; }

    public string[] Strengths { get; set; } = [];

    public string[] Weaknesses { get; set; } = [];

    public string[] RecommendedTopics { get; set; } = [];

    public string? RawResult { get; set; }
}
