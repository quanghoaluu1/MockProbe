using MockProbe.Domain.Common;
using MockProbe.Domain.QuestionBank;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MockProbe.Infrastructure.Data.Configurations;

internal sealed class QuestionCategoryConfiguration : IEntityTypeConfiguration<QuestionCategory>
{
    public void Configure(EntityTypeBuilder<QuestionCategory> builder)
    {
        builder.ToTable("question_categories", DomainSchemas.QuestionBank);
        builder.ConfigureAuditing();

        builder.Property(category => category.Name).HasMaxLength(120).IsRequired();
        builder.Property(category => category.Slug).HasMaxLength(140).IsRequired();
        builder.Property(category => category.Description).HasMaxLength(1000);

        builder.HasIndex(category => category.Slug).IsUnique();
        builder.HasData(SeedData.QuestionCategories);
    }
}

internal sealed class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.ToTable("skills", DomainSchemas.QuestionBank);
        builder.ConfigureAuditing();

        builder.Property(skill => skill.Name).HasMaxLength(120).IsRequired();
        builder.Property(skill => skill.Slug).HasMaxLength(140).IsRequired();
        builder.Property(skill => skill.Description).HasMaxLength(1000);

        builder.HasIndex(skill => skill.Name).IsUnique();
        builder.HasIndex(skill => skill.Slug).IsUnique();
        builder.HasData(SeedData.Skills);
    }
}

internal sealed class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("questions", DomainSchemas.QuestionBank);
        builder.ConfigureAuditing();

        builder.Property(question => question.Title).HasMaxLength(240).IsRequired();
        builder.Property(question => question.Prompt).IsRequired();
        builder.Property(question => question.Guidance);
        builder.Property(question => question.Type).HasConversion<string>().HasMaxLength(60).IsRequired();
        builder.Property(question => question.Difficulty).HasConversion<string>().HasMaxLength(60).IsRequired();
        builder.Property(question => question.Metadata).HasJsonbColumn();

        builder.HasIndex(question => question.CategoryId);
        builder.HasIndex(question => question.CreatedByUserId);
        builder.HasData(SeedData.Questions);
    }
}

internal sealed class QuestionSkillConfiguration : IEntityTypeConfiguration<QuestionSkill>
{
    public void Configure(EntityTypeBuilder<QuestionSkill> builder)
    {
        builder.ToTable("question_skills", DomainSchemas.QuestionBank);
        builder.ConfigureAuditing();

        builder.HasIndex(questionSkill => new { questionSkill.QuestionId, questionSkill.SkillId }).IsUnique();
        builder.HasData(SeedData.QuestionSkills);
    }
}

internal sealed class QuestionTagConfiguration : IEntityTypeConfiguration<QuestionTag>
{
    public void Configure(EntityTypeBuilder<QuestionTag> builder)
    {
        builder.ToTable("question_tags", DomainSchemas.QuestionBank);
        builder.ConfigureAuditing();

        builder.Property(tag => tag.Name).HasMaxLength(80).IsRequired();
        builder.Property(tag => tag.Slug).HasMaxLength(100).IsRequired();
        builder.HasIndex(tag => new { tag.QuestionId, tag.Slug }).IsUnique();
    }
}

internal sealed class InterviewTemplateConfiguration : IEntityTypeConfiguration<InterviewTemplate>
{
    public void Configure(EntityTypeBuilder<InterviewTemplate> builder)
    {
        builder.ToTable("interview_templates", DomainSchemas.QuestionBank);
        builder.ConfigureAuditing();

        builder.Property(template => template.Name).HasMaxLength(180).IsRequired();
        builder.Property(template => template.Slug).HasMaxLength(220).IsRequired();
        builder.Property(template => template.Description).HasMaxLength(2000);
        builder.Property(template => template.TargetRole).HasMaxLength(160);
        builder.Property(template => template.Difficulty).HasConversion<string>().HasMaxLength(60);
        builder.Property(template => template.Status).HasConversion<string>().HasMaxLength(60).IsRequired();
        builder.Property(template => template.Settings).HasJsonbColumn();

        builder.HasIndex(template => template.Slug).IsUnique();
        builder.HasData(SeedData.GeneralTemplate);
    }
}

internal sealed class InterviewTemplateQuestionConfiguration : IEntityTypeConfiguration<InterviewTemplateQuestion>
{
    public void Configure(EntityTypeBuilder<InterviewTemplateQuestion> builder)
    {
        builder.ToTable("interview_template_questions", DomainSchemas.QuestionBank);
        builder.ConfigureAuditing();

        builder.HasIndex(item => new { item.InterviewTemplateId, item.Position }).IsUnique();
        builder.HasData(SeedData.InterviewTemplateQuestions);
    }
}
