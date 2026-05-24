using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;
using MockProbe.Domain.Identity;

namespace MockProbe.Domain.QuestionBank;

public sealed class Question : AuditableEntity
{
    public Guid CategoryId { get; set; }

    public Guid CreatedByUserId { get; set; } = DefaultLocalUser.Id;

    public string Title { get; set; } = string.Empty;

    public string Prompt { get; set; } = string.Empty;

    public string? Guidance { get; set; }

    public QuestionType Type { get; set; }

    public QuestionDifficulty Difficulty { get; set; }

    public bool IsPublic { get; set; }

    public string? Metadata { get; set; }
}
