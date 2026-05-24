using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;
using MockProbe.Domain.Identity;

namespace MockProbe.Domain.Interview;

public sealed class JobDescription : AuditableEntity
{
    public Guid UserId { get; set; } = DefaultLocalUser.Id;

    public string Title { get; set; } = string.Empty;

    public string? CompanyName { get; set; }

    public string DescriptionText { get; set; } = string.Empty;

    public string? ParsedJson { get; set; }

    public string[] Skills { get; set; } = [];

    public DocumentSourceType SourceType { get; set; } = DocumentSourceType.Manual;
}
