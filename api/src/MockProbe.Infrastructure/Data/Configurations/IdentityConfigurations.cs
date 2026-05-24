using MockProbe.Domain.Common;
using MockProbe.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MockProbe.Infrastructure.Data.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users", DomainSchemas.Identity);
        builder.ConfigureAuditing();

        builder.Property(user => user.Email).HasMaxLength(320);
        builder.Property(user => user.Username).HasMaxLength(80).IsRequired();
        builder.Property(user => user.FullName).HasMaxLength(200).IsRequired();
        builder.Property(user => user.AuthProvider).HasConversion<string>().HasMaxLength(40).IsRequired();
        builder.Property(user => user.Role).HasConversion<string>().HasMaxLength(40).IsRequired();
        builder.Property(user => user.Status).HasConversion<string>().HasMaxLength(40).IsRequired();
        builder.Property(user => user.PasswordHash).HasMaxLength(500);
        builder.Property(user => user.ExternalSubject).HasMaxLength(300);
        builder.Property(user => user.Settings).HasJsonbColumn();

        builder.HasIndex(user => user.Username).IsUnique();
        builder.HasIndex(user => user.Email).IsUnique().HasFilter("email IS NOT NULL");

        builder.HasData(SeedData.LocalAdminUser);
    }
}

internal sealed class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable("user_profiles", DomainSchemas.Identity);
        builder.ConfigureAuditing();

        builder.Property(profile => profile.DisplayName).HasMaxLength(120);
        builder.Property(profile => profile.Bio).HasMaxLength(2000);
        builder.Property(profile => profile.TargetRole).HasMaxLength(160);
        builder.Property(profile => profile.ExperienceLevel).HasMaxLength(80);
        builder.Property(profile => profile.PreferredLanguage).HasMaxLength(40);
        builder.Property(profile => profile.Skills).HasColumnType("text[]");
        builder.Property(profile => profile.Settings).HasJsonbColumn();

        builder.HasIndex(profile => profile.UserId).IsUnique();
    }
}

internal sealed class GuestSessionConfiguration : IEntityTypeConfiguration<GuestSession>
{
    public void Configure(EntityTypeBuilder<GuestSession> builder)
    {
        builder.ToTable("guest_sessions", DomainSchemas.Identity);
        builder.ConfigureAuditing();

        builder.Property(session => session.SessionTokenHash).HasMaxLength(500).IsRequired();
        builder.Property(session => session.Status).HasConversion<string>().HasMaxLength(40).IsRequired();
        builder.Property(session => session.ExpiresAt).IsRequired();

        builder.HasIndex(session => session.SessionTokenHash).IsUnique();
    }
}
