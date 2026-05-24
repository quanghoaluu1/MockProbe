using MockProbe.Domain.Common;

namespace MockProbe.Domain.QuestionBank;

public sealed class Skill : AuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string? Description { get; set; }
}
