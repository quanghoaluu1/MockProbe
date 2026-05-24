using MockProbe.Domain.Enums;
using MockProbe.Domain.Identity;
using MockProbe.Domain.QuestionBank;
using MockProbe.Domain.Ai;
using DefaultUser = MockProbe.Domain.Identity.DefaultLocalUser;

namespace MockProbe.Infrastructure.Data;

internal static class SeedData
{
    public static readonly DateTimeOffset SeededAt = DateTimeOffset.UnixEpoch;

    public static readonly Guid BehavioralCategoryId = Guid.Parse("10000000-0000-0000-0000-000000000001");
    public static readonly Guid TechnicalCategoryId = Guid.Parse("10000000-0000-0000-0000-000000000002");
    public static readonly Guid SystemDesignCategoryId = Guid.Parse("10000000-0000-0000-0000-000000000003");

    public static readonly Guid CommunicationSkillId = Guid.Parse("20000000-0000-0000-0000-000000000001");
    public static readonly Guid ProblemSolvingSkillId = Guid.Parse("20000000-0000-0000-0000-000000000002");
    public static readonly Guid SystemDesignSkillId = Guid.Parse("20000000-0000-0000-0000-000000000003");

    public static readonly Guid TellMeAboutYourselfQuestionId = Guid.Parse("30000000-0000-0000-0000-000000000001");
    public static readonly Guid DifficultBugQuestionId = Guid.Parse("30000000-0000-0000-0000-000000000002");
    public static readonly Guid ScalableApiQuestionId = Guid.Parse("30000000-0000-0000-0000-000000000003");

    public static readonly Guid GeneralTemplateId = Guid.Parse("40000000-0000-0000-0000-000000000001");

    public static readonly Guid InterviewerPromptId = Guid.Parse("50000000-0000-0000-0000-000000000001");
    public static readonly Guid EvaluationPromptId = Guid.Parse("50000000-0000-0000-0000-000000000002");

    public static User LocalAdminUser => new()
    {
        Id = DefaultLocalUserId,
        Email = DefaultUser.Email,
        Username = DefaultUser.Username,
        FullName = DefaultUser.FullName,
        AuthProvider = DefaultUser.AuthProvider,
        Role = DefaultUser.Role,
        Status = DefaultUser.Status,
        IsSystemUser = DefaultUser.IsSystemUser,
        Settings = "{}",
        CreatedAt = SeededAt
    };

    public static Guid DefaultLocalUserId => DefaultUser.Id;

    public static QuestionCategory[] QuestionCategories =>
    [
        new() { Id = BehavioralCategoryId, Name = "Behavioral", Slug = "behavioral", Description = "Communication, collaboration, and experience questions.", SortOrder = 10, CreatedAt = SeededAt },
        new() { Id = TechnicalCategoryId, Name = "Technical", Slug = "technical", Description = "Practical engineering and problem-solving questions.", SortOrder = 20, CreatedAt = SeededAt },
        new() { Id = SystemDesignCategoryId, Name = "System Design", Slug = "system-design", Description = "Architecture and tradeoff discussion questions.", SortOrder = 30, CreatedAt = SeededAt }
    ];

    public static Skill[] Skills =>
    [
        new() { Id = CommunicationSkillId, Name = "Communication", Slug = "communication", Description = "Clear, structured verbal answers.", CreatedAt = SeededAt },
        new() { Id = ProblemSolvingSkillId, Name = "Problem Solving", Slug = "problem-solving", Description = "Debugging, reasoning, and decision-making.", CreatedAt = SeededAt },
        new() { Id = SystemDesignSkillId, Name = "System Design", Slug = "system-design", Description = "Designing reliable and scalable systems.", CreatedAt = SeededAt }
    ];

    public static Question[] Questions =>
    [
        new()
        {
            Id = TellMeAboutYourselfQuestionId,
            CategoryId = BehavioralCategoryId,
            CreatedByUserId = DefaultLocalUserId,
            Title = "Tell me about yourself",
            Prompt = "Give a concise overview of your background, strengths, and what you are looking to practice.",
            Type = QuestionType.Behavioral,
            Difficulty = QuestionDifficulty.Beginner,
            IsPublic = true,
            Metadata = "{}",
            CreatedAt = SeededAt
        },
        new()
        {
            Id = DifficultBugQuestionId,
            CategoryId = TechnicalCategoryId,
            CreatedByUserId = DefaultLocalUserId,
            Title = "Describe a difficult bug you fixed",
            Prompt = "Walk through a difficult bug, how you isolated it, and what you changed to prevent it from recurring.",
            Type = QuestionType.Technical,
            Difficulty = QuestionDifficulty.Intermediate,
            IsPublic = true,
            Metadata = "{}",
            CreatedAt = SeededAt
        },
        new()
        {
            Id = ScalableApiQuestionId,
            CategoryId = SystemDesignCategoryId,
            CreatedByUserId = DefaultLocalUserId,
            Title = "Design a scalable interview practice API",
            Prompt = "Design an API that supports mock interview sessions, answer storage, and asynchronous AI evaluation.",
            Type = QuestionType.SystemDesign,
            Difficulty = QuestionDifficulty.Advanced,
            IsPublic = true,
            Metadata = "{}",
            CreatedAt = SeededAt
        }
    ];

    public static QuestionSkill[] QuestionSkills =>
    [
        new() { Id = Guid.Parse("31000000-0000-0000-0000-000000000001"), QuestionId = TellMeAboutYourselfQuestionId, SkillId = CommunicationSkillId, Weight = 3, CreatedAt = SeededAt },
        new() { Id = Guid.Parse("31000000-0000-0000-0000-000000000002"), QuestionId = DifficultBugQuestionId, SkillId = ProblemSolvingSkillId, Weight = 3, CreatedAt = SeededAt },
        new() { Id = Guid.Parse("31000000-0000-0000-0000-000000000003"), QuestionId = ScalableApiQuestionId, SkillId = SystemDesignSkillId, Weight = 3, CreatedAt = SeededAt }
    ];

    public static InterviewTemplate GeneralTemplate => new()
    {
        Id = GeneralTemplateId,
        CreatedByUserId = DefaultLocalUserId,
        Name = "General Mock Interview",
        Slug = "general-mock-interview",
        Description = "A balanced starter practice session for self-hosted mock interviews.",
        TargetRole = "Software Engineer",
        Difficulty = QuestionDifficulty.Intermediate,
        Status = TemplateStatus.Published,
        IsPublic = true,
        Settings = "{}",
        CreatedAt = SeededAt
    };

    public static InterviewTemplateQuestion[] InterviewTemplateQuestions =>
    [
        new() { Id = Guid.Parse("41000000-0000-0000-0000-000000000001"), InterviewTemplateId = GeneralTemplateId, QuestionId = TellMeAboutYourselfQuestionId, Position = 1, IsRequired = true, CreatedAt = SeededAt },
        new() { Id = Guid.Parse("41000000-0000-0000-0000-000000000002"), InterviewTemplateId = GeneralTemplateId, QuestionId = DifficultBugQuestionId, Position = 2, IsRequired = true, CreatedAt = SeededAt },
        new() { Id = Guid.Parse("41000000-0000-0000-0000-000000000003"), InterviewTemplateId = GeneralTemplateId, QuestionId = ScalableApiQuestionId, Position = 3, IsRequired = false, CreatedAt = SeededAt }
    ];

    public static PromptTemplate[] PromptTemplates =>
    [
        new()
        {
            Id = InterviewerPromptId,
            Key = "default_interviewer",
            Name = "Default Interviewer",
            Type = PromptTemplateType.Interviewer,
            TemplateText = "You are a focused mock interviewer helping a user practice. Ask one question at a time.",
            Variables = "{\"variables\":[\"session\",\"question\"]}",
            Description = "Default conversational interviewer prompt.",
            Version = 1,
            IsActive = true,
            CreatedAt = SeededAt
        },
        new()
        {
            Id = EvaluationPromptId,
            Key = "default_answer_evaluation",
            Name = "Default Answer Evaluation",
            Type = PromptTemplateType.AnswerEvaluation,
            TemplateText = "Evaluate the user's answer for relevance, clarity, depth, structure, and communication.",
            Variables = "{\"variables\":[\"question\",\"answer\"]}",
            Description = "Default answer scoring prompt.",
            Version = 1,
            IsActive = true,
            CreatedAt = SeededAt
        }
    ];
}
