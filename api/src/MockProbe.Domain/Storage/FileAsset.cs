using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;
using MockProbe.Domain.Identity;

namespace MockProbe.Domain.Storage;

public sealed class FileAsset : AuditableEntity
{
    public Guid UserId { get; set; } = DefaultLocalUser.Id;

    public FileAssetKind Kind { get; set; }

    public FileAssetStatus Status { get; set; } = FileAssetStatus.Pending;

    public string OriginalFileName { get; set; } = string.Empty;

    public string StorageBucket { get; set; } = string.Empty;

    public string StorageKey { get; set; } = string.Empty;

    public string ContentType { get; set; } = string.Empty;

    public long SizeBytes { get; set; }

    public string? ChecksumSha256 { get; set; }
}
