using MockProbe.Domain.Ai;
using MockProbe.Domain.Community;
using MockProbe.Domain.Identity;
using MockProbe.Domain.Interview;
using MockProbe.Domain.QuestionBank;
using MockProbe.Domain.Storage;
using AppSetting = MockProbe.Domain.System.AppSetting;
using Microsoft.EntityFrameworkCore;

namespace MockProbe.Infrastructure.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<GuestSession> GuestSessions => Set<GuestSession>();

    public DbSet<QuestionCategory> QuestionCategories => Set<QuestionCategory>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<QuestionSkill> QuestionSkills => Set<QuestionSkill>();
    public DbSet<QuestionTag> QuestionTags => Set<QuestionTag>();
    public DbSet<InterviewTemplate> InterviewTemplates => Set<InterviewTemplate>();
    public DbSet<InterviewTemplateQuestion> InterviewTemplateQuestions => Set<InterviewTemplateQuestion>();

    public DbSet<Resume> Resumes => Set<Resume>();
    public DbSet<JobDescription> JobDescriptions => Set<JobDescription>();
    public DbSet<PracticeSession> PracticeSessions => Set<PracticeSession>();
    public DbSet<SessionQuestion> SessionQuestions => Set<SessionQuestion>();
    public DbSet<SessionMessage> SessionMessages => Set<SessionMessage>();
    public DbSet<UserAnswer> UserAnswers => Set<UserAnswer>();

    public DbSet<PromptTemplate> PromptTemplates => Set<PromptTemplate>();
    public DbSet<ModelRun> ModelRuns => Set<ModelRun>();
    public DbSet<AnswerEvaluation> AnswerEvaluations => Set<AnswerEvaluation>();
    public DbSet<AnswerEvaluationScore> AnswerEvaluationScores => Set<AnswerEvaluationScore>();
    public DbSet<SessionEvaluation> SessionEvaluations => Set<SessionEvaluation>();

    public DbSet<FileAsset> FileAssets => Set<FileAsset>();

    public DbSet<CommunityVote> CommunityVotes => Set<CommunityVote>();
    public DbSet<UserBookmark> UserBookmarks => Set<UserBookmark>();

    public DbSet<AppSetting> AppSettings => Set<AppSetting>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
