using MockProbe.Domain.Common;

namespace MockProbe.Domain.QuestionBank;

public sealed class QuestionTag : AuditableEntity
{
    public Guid QuestionId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;
}
