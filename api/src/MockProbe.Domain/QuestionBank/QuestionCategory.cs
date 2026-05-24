using MockProbe.Domain.Common;

namespace MockProbe.Domain.QuestionBank;

public sealed class QuestionCategory : AuditableEntity
{
    public Guid? ParentCategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int SortOrder { get; set; }
}
