using MockProbe.Domain.Common;
using MockProbe.Domain.Community;
using MockProbe.Domain.Storage;
using AppSetting = MockProbe.Domain.System.AppSetting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MockProbe.Infrastructure.Data.Configurations;

internal sealed class FileAssetConfiguration : IEntityTypeConfiguration<FileAsset>
{
    public void Configure(EntityTypeBuilder<FileAsset> builder)
    {
        builder.ToTable("file_assets", DomainSchemas.Storage);
        builder.ConfigureAuditing();

        builder.Property(file => file.Kind).HasConversion<string>().HasMaxLength(60).IsRequired();
        builder.Property(file => file.Status).HasConversion<string>().HasMaxLength(60).IsRequired();
        builder.Property(file => file.OriginalFileName).HasMaxLength(300).IsRequired();
        builder.Property(file => file.StorageBucket).HasMaxLength(120).IsRequired();
        builder.Property(file => file.StorageKey).HasMaxLength(600).IsRequired();
        builder.Property(file => file.ContentType).HasMaxLength(160).IsRequired();
        builder.Property(file => file.ChecksumSha256).HasMaxLength(64);

        builder.HasIndex(file => new { file.UserId, file.CreatedAt });
        builder.HasIndex(file => new { file.StorageBucket, file.StorageKey }).IsUnique();
    }
}

internal sealed class CommunityVoteConfiguration : IEntityTypeConfiguration<CommunityVote>
{
    public void Configure(EntityTypeBuilder<CommunityVote> builder)
    {
        builder.ToTable("community_votes", DomainSchemas.Community);
        builder.ConfigureAuditing();

        builder.Property(vote => vote.EntityType).HasMaxLength(80).IsRequired();
        builder.Property(vote => vote.VoteType).HasConversion<string>().HasMaxLength(40).IsRequired();

        builder.HasIndex(vote => new { vote.UserId, vote.EntityType, vote.EntityId }).IsUnique();
    }
}

internal sealed class UserBookmarkConfiguration : IEntityTypeConfiguration<UserBookmark>
{
    public void Configure(EntityTypeBuilder<UserBookmark> builder)
    {
        builder.ToTable("user_bookmarks", DomainSchemas.Community);
        builder.ConfigureAuditing();

        builder.Property(bookmark => bookmark.EntityType).HasMaxLength(80).IsRequired();
        builder.Property(bookmark => bookmark.Notes).HasMaxLength(1000);

        builder.HasIndex(bookmark => new { bookmark.UserId, bookmark.EntityType, bookmark.EntityId }).IsUnique();
    }
}

internal sealed class AppSettingConfiguration : IEntityTypeConfiguration<AppSetting>
{
    public void Configure(EntityTypeBuilder<AppSetting> builder)
    {
        builder.ToTable("app_settings", DomainSchemas.System);
        builder.ConfigureAuditing();

        builder.Property(setting => setting.Key).HasMaxLength(160).IsRequired();
        builder.Property(setting => setting.Value).HasRequiredJsonbColumn();
        builder.Property(setting => setting.ValueType).HasConversion<string>().HasMaxLength(80).IsRequired();
        builder.Property(setting => setting.Description).HasMaxLength(1000);

        builder.HasIndex(setting => setting.Key).IsUnique();
    }
}
