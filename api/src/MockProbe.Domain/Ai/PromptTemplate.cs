using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;

namespace MockProbe.Domain.Ai;

public sealed class PromptTemplate : AuditableEntity
{
    public string Key { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public PromptTemplateType Type { get; set; }

    public string TemplateText { get; set; } = string.Empty;

    public string? Variables { get; set; }

    public string? Description { get; set; }

    public int Version { get; set; } = 1;

    public bool IsActive { get; set; } = true;
}
