using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;
using MockProbe.Domain.Identity;

namespace MockProbe.Domain.Interview;

public sealed class Resume : AuditableEntity
{
    public Guid UserId { get; set; } = DefaultLocalUser.Id;

    public Guid? FileAssetId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? RawText { get; set; }

    public string? ParsedJson { get; set; }

    public string[] Skills { get; set; } = [];

    public DocumentSourceType SourceType { get; set; } = DocumentSourceType.Manual;
}
