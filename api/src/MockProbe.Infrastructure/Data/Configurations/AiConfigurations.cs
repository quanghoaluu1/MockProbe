using MockProbe.Domain.Ai;
using MockProbe.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MockProbe.Infrastructure.Data.Configurations;

internal sealed class PromptTemplateConfiguration : IEntityTypeConfiguration<PromptTemplate>
{
    public void Configure(EntityTypeBuilder<PromptTemplate> builder)
    {
        builder.ToTable("prompt_templates", DomainSchemas.Ai);
        builder.ConfigureAuditing();

        builder.Property(prompt => prompt.Key).HasMaxLength(120).IsRequired();
        builder.Property(prompt => prompt.Name).HasMaxLength(180).IsRequired();
        builder.Property(prompt => prompt.Type).HasConversion<string>().HasMaxLength(80).IsRequired();
        builder.Property(prompt => prompt.TemplateText).IsRequired();
        builder.Property(prompt => prompt.Variables).HasJsonbColumn();
        builder.Property(prompt => prompt.Description).HasMaxLength(1000);

        builder.HasIndex(prompt => prompt.Key).IsUnique();
        builder.HasData(SeedData.PromptTemplates);
    }
}

internal sealed class ModelRunConfiguration : IEntityTypeConfiguration<ModelRun>
{
    public void Configure(EntityTypeBuilder<ModelRun> builder)
    {
        builder.ToTable("model_runs", DomainSchemas.Ai);
        builder.ConfigureAuditing();

        builder.Property(run => run.Provider).HasConversion<string>().HasMaxLength(80).IsRequired();
        builder.Property(run => run.ModelName).HasMaxLength(160).IsRequired();
        builder.Property(run => run.Status).HasConversion<string>().HasMaxLength(60).IsRequired();
        builder.Property(run => run.RequestPayload).HasJsonbColumn();
        builder.Property(run => run.ResponsePayload).HasJsonbColumn();
        builder.Property(run => run.ErrorMessage);

        builder.HasIndex(run => run.PracticeSessionId);
        builder.HasIndex(run => run.PromptTemplateId);
    }
}

internal sealed class AnswerEvaluationConfiguration : IEntityTypeConfiguration<AnswerEvaluation>
{
    public void Configure(EntityTypeBuilder<AnswerEvaluation> builder)
    {
        builder.ToTable("answer_evaluations", DomainSchemas.Ai);
        builder.ConfigureAuditing();

        builder.Property(evaluation => evaluation.Status).HasConversion<string>().HasMaxLength(60).IsRequired();
        builder.Property(evaluation => evaluation.OverallScore).HasPrecision(5, 2);
        builder.Property(evaluation => evaluation.Summary);
        builder.Property(evaluation => evaluation.Strengths).HasColumnType("text[]");
        builder.Property(evaluation => evaluation.Weaknesses).HasColumnType("text[]");
        builder.Property(evaluation => evaluation.RecommendedTopics).HasColumnType("text[]");
        builder.Property(evaluation => evaluation.RawResult).HasJsonbColumn();

        builder.HasIndex(evaluation => evaluation.UserAnswerId);
        builder.HasIndex(evaluation => evaluation.ModelRunId);
    }
}

internal sealed class AnswerEvaluationScoreConfiguration : IEntityTypeConfiguration<AnswerEvaluationScore>
{
    public void Configure(EntityTypeBuilder<AnswerEvaluationScore> builder)
    {
        builder.ToTable("answer_evaluation_scores", DomainSchemas.Ai);
        builder.ConfigureAuditing();

        builder.Property(score => score.Type).HasConversion<string>().HasMaxLength(80).IsRequired();
        builder.Property(score => score.Score).HasPrecision(5, 2);
        builder.Property(score => score.MaxScore).HasPrecision(5, 2);
        builder.Property(score => score.Rationale);

        builder.HasIndex(score => new { score.AnswerEvaluationId, score.Type }).IsUnique();
    }
}

internal sealed class SessionEvaluationConfiguration : IEntityTypeConfiguration<SessionEvaluation>
{
    public void Configure(EntityTypeBuilder<SessionEvaluation> builder)
    {
        builder.ToTable("session_evaluations", DomainSchemas.Ai);
        builder.ConfigureAuditing();

        builder.Property(evaluation => evaluation.Status).HasConversion<string>().HasMaxLength(60).IsRequired();
        builder.Property(evaluation => evaluation.OverallScore).HasPrecision(5, 2);
        builder.Property(evaluation => evaluation.Summary);
        builder.Property(evaluation => evaluation.Strengths).HasColumnType("text[]");
        builder.Property(evaluation => evaluation.Weaknesses).HasColumnType("text[]");
        builder.Property(evaluation => evaluation.RecommendedTopics).HasColumnType("text[]");
        builder.Property(evaluation => evaluation.RawResult).HasJsonbColumn();

        builder.HasIndex(evaluation => evaluation.PracticeSessionId).IsUnique();
        builder.HasIndex(evaluation => evaluation.ModelRunId);
    }
}
