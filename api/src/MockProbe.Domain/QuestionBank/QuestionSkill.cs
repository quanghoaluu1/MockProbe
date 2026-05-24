using MockProbe.Domain.Common;

namespace MockProbe.Domain.QuestionBank;

public sealed class QuestionSkill : AuditableEntity
{
    public Guid QuestionId { get; set; }

    public Guid SkillId { get; set; }

    public int Weight { get; set; } = 1;
}
