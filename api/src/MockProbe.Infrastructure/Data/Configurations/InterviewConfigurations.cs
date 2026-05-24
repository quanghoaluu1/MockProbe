using MockProbe.Domain.Common;
using MockProbe.Domain.Interview;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MockProbe.Infrastructure.Data.Configurations;

internal sealed class ResumeConfiguration : IEntityTypeConfiguration<Resume>
{
    public void Configure(EntityTypeBuilder<Resume> builder)
    {
        builder.ToTable("resumes", DomainSchemas.Interview);
        builder.ConfigureAuditing();

        builder.Property(resume => resume.Title).HasMaxLength(180).IsRequired();
        builder.Property(resume => resume.RawText);
        builder.Property(resume => resume.ParsedJson).HasJsonbColumn();
        builder.Property(resume => resume.SourceType).HasConversion<string>().HasMaxLength(60).IsRequired();
        builder.Property(resume => resume.Skills).HasColumnType("text[]");

        builder.HasIndex(resume => new { resume.UserId, resume.CreatedAt });
    }
}

internal sealed class JobDescriptionConfiguration : IEntityTypeConfiguration<JobDescription>
{
    public void Configure(EntityTypeBuilder<JobDescription> builder)
    {
        builder.ToTable("job_descriptions", DomainSchemas.Interview);
        builder.ConfigureAuditing();

        builder.Property(job => job.Title).HasMaxLength(180).IsRequired();
        builder.Property(job => job.CompanyName).HasMaxLength(180);
        builder.Property(job => job.DescriptionText).IsRequired();
        builder.Property(job => job.ParsedJson).HasJsonbColumn();
        builder.Property(job => job.SourceType).HasConversion<string>().HasMaxLength(60).IsRequired();
        builder.Property(job => job.Skills).HasColumnType("text[]");

        builder.HasIndex(job => new { job.UserId, job.CreatedAt });
    }
}

internal sealed class PracticeSessionConfiguration : IEntityTypeConfiguration<PracticeSession>
{
    public void Configure(EntityTypeBuilder<PracticeSession> builder)
    {
        builder.ToTable("practice_sessions", DomainSchemas.Interview);
        builder.ConfigureAuditing();

        builder.Property(session => session.Title).HasMaxLength(220).IsRequired();
        builder.Property(session => session.Status).HasConversion<string>().HasMaxLength(60).IsRequired();
        builder.Property(session => session.ShareToken).HasMaxLength(120);
        builder.Property(session => session.Settings).HasJsonbColumn();

        builder.HasIndex(session => new { session.UserId, session.CreatedAt });
        builder.HasIndex(session => session.ShareToken).IsUnique().HasFilter("share_token IS NOT NULL");
    }
}

internal sealed class SessionQuestionConfiguration : IEntityTypeConfiguration<SessionQuestion>
{
    public void Configure(EntityTypeBuilder<SessionQuestion> builder)
    {
        builder.ToTable("session_questions", DomainSchemas.Interview);
        builder.ConfigureAuditing();

        builder.Property(question => question.Prompt).IsRequired();
        builder.Property(question => question.Status).HasConversion<string>().HasMaxLength(60).IsRequired();
        builder.Property(question => question.Metadata).HasJsonbColumn();

        builder.HasIndex(question => new { question.PracticeSessionId, question.Position }).IsUnique();
    }
}

internal sealed class SessionMessageConfiguration : IEntityTypeConfiguration<SessionMessage>
{
    public void Configure(EntityTypeBuilder<SessionMessage> builder)
    {
        builder.ToTable("session_messages", DomainSchemas.Interview);
        builder.ConfigureAuditing();

        builder.Property(message => message.Role).HasConversion<string>().HasMaxLength(40).IsRequired();
        builder.Property(message => message.Content).IsRequired();
        builder.Property(message => message.Metadata).HasJsonbColumn();

        builder.HasIndex(message => new { message.PracticeSessionId, message.SequenceNumber });
    }
}

internal sealed class UserAnswerConfiguration : IEntityTypeConfiguration<UserAnswer>
{
    public void Configure(EntityTypeBuilder<UserAnswer> builder)
    {
        builder.ToTable("user_answers", DomainSchemas.Interview);
        builder.ConfigureAuditing();

        builder.Property(answer => answer.AnswerText).IsRequired();
        builder.Property(answer => answer.Status).HasConversion<string>().HasMaxLength(60).IsRequired();

        builder.HasIndex(answer => answer.SessionQuestionId).IsUnique();
        builder.HasIndex(answer => answer.PracticeSessionId);
    }
}
