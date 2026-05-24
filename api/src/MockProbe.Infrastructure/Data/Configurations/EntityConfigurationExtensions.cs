using MockProbe.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MockProbe.Infrastructure.Data.Configurations;

internal static class EntityConfigurationExtensions
{
    public static EntityTypeBuilder<TEntity> ConfigureAuditing<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : AuditableEntity
    {
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id).ValueGeneratedNever();
        builder.Property(entity => entity.CreatedAt).IsRequired();
        builder.Property(entity => entity.UpdatedAt);
        builder.Property(entity => entity.DeletedAt);

        return builder;
    }

    public static PropertyBuilder<string?> HasJsonbColumn(this PropertyBuilder<string?> builder)
    {
        return builder.HasColumnType("jsonb");
    }

    public static PropertyBuilder<string> HasRequiredJsonbColumn(this PropertyBuilder<string> builder)
    {
        return builder.HasColumnType("jsonb").IsRequired();
    }
}
