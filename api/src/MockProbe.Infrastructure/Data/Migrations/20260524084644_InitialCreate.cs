using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MockProbe.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ai");

            migrationBuilder.EnsureSchema(
                name: "system");

            migrationBuilder.EnsureSchema(
                name: "community");

            migrationBuilder.EnsureSchema(
                name: "storage");

            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.EnsureSchema(
                name: "question_bank");

            migrationBuilder.EnsureSchema(
                name: "interview");

            migrationBuilder.CreateTable(
                name: "answer_evaluation_scores",
                schema: "ai",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    answer_evaluation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    score = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    max_score = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    rationale = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_answer_evaluation_scores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "answer_evaluations",
                schema: "ai",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_answer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    model_run_id = table.Column<Guid>(type: "uuid", nullable: true),
                    status = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    overall_score = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    summary = table.Column<string>(type: "text", nullable: true),
                    strengths = table.Column<string[]>(type: "text[]", nullable: false),
                    weaknesses = table.Column<string[]>(type: "text[]", nullable: false),
                    recommended_topics = table.Column<string[]>(type: "text[]", nullable: false),
                    raw_result = table.Column<string>(type: "jsonb", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_answer_evaluations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "app_settings",
                schema: "system",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    key = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    value = table.Column<string>(type: "jsonb", nullable: false),
                    value_type = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    is_secret = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_app_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "community_votes",
                schema: "community",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entity_type = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    entity_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vote_type = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_community_votes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "file_assets",
                schema: "storage",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kind = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    status = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    original_file_name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    storage_bucket = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    storage_key = table.Column<string>(type: "character varying(600)", maxLength: 600, nullable: false),
                    content_type = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    size_bytes = table.Column<long>(type: "bigint", nullable: false),
                    checksum_sha256 = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_file_assets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "guest_sessions",
                schema: "identity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    converted_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    session_token_hash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    status = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    expires_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    converted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_guest_sessions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "interview_template_questions",
                schema: "question_bank",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    interview_template_id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    position = table.Column<int>(type: "integer", nullable: false),
                    is_required = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_interview_template_questions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "interview_templates",
                schema: "question_bank",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    slug = table.Column<string>(type: "character varying(220)", maxLength: 220, nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    target_role = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: true),
                    difficulty = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    status = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    is_public = table.Column<bool>(type: "boolean", nullable: false),
                    settings = table.Column<string>(type: "jsonb", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_interview_templates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job_descriptions",
                schema: "interview",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    company_name = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: true),
                    description_text = table.Column<string>(type: "text", nullable: false),
                    parsed_json = table.Column<string>(type: "jsonb", nullable: true),
                    skills = table.Column<string[]>(type: "text[]", nullable: false),
                    source_type = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_descriptions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "model_runs",
                schema: "ai",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    practice_session_id = table.Column<Guid>(type: "uuid", nullable: true),
                    prompt_template_id = table.Column<Guid>(type: "uuid", nullable: true),
                    provider = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    model_name = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    status = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    request_payload = table.Column<string>(type: "jsonb", nullable: true),
                    response_payload = table.Column<string>(type: "jsonb", nullable: true),
                    error_message = table.Column<string>(type: "text", nullable: true),
                    prompt_tokens = table.Column<int>(type: "integer", nullable: true),
                    completion_tokens = table.Column<int>(type: "integer", nullable: true),
                    started_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    completed_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_model_runs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "practice_sessions",
                schema: "interview",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    resume_id = table.Column<Guid>(type: "uuid", nullable: true),
                    job_description_id = table.Column<Guid>(type: "uuid", nullable: true),
                    interview_template_id = table.Column<Guid>(type: "uuid", nullable: true),
                    title = table.Column<string>(type: "character varying(220)", maxLength: 220, nullable: false),
                    status = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    share_token = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    settings = table.Column<string>(type: "jsonb", nullable: true),
                    started_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    completed_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_practice_sessions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "prompt_templates",
                schema: "ai",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    key = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    name = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    type = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    template_text = table.Column<string>(type: "text", nullable: false),
                    variables = table.Column<string>(type: "jsonb", nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    version = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_prompt_templates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "question_categories",
                schema: "question_bank",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parent_category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    slug = table.Column<string>(type: "character varying(140)", maxLength: 140, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    sort_order = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "question_skills",
                schema: "question_bank",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    skill_id = table.Column<Guid>(type: "uuid", nullable: false),
                    weight = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question_skills", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "question_tags",
                schema: "question_bank",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    slug = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question_tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                schema: "question_bank",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(240)", maxLength: 240, nullable: false),
                    prompt = table.Column<string>(type: "text", nullable: false),
                    guidance = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    difficulty = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    is_public = table.Column<bool>(type: "boolean", nullable: false),
                    metadata = table.Column<string>(type: "jsonb", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_questions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "resumes",
                schema: "interview",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    file_asset_id = table.Column<Guid>(type: "uuid", nullable: true),
                    title = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    raw_text = table.Column<string>(type: "text", nullable: true),
                    parsed_json = table.Column<string>(type: "jsonb", nullable: true),
                    skills = table.Column<string[]>(type: "text[]", nullable: false),
                    source_type = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_resumes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "session_evaluations",
                schema: "ai",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    practice_session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    model_run_id = table.Column<Guid>(type: "uuid", nullable: true),
                    status = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    overall_score = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    summary = table.Column<string>(type: "text", nullable: true),
                    strengths = table.Column<string[]>(type: "text[]", nullable: false),
                    weaknesses = table.Column<string[]>(type: "text[]", nullable: false),
                    recommended_topics = table.Column<string[]>(type: "text[]", nullable: false),
                    raw_result = table.Column<string>(type: "jsonb", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_session_evaluations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "session_messages",
                schema: "interview",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    practice_session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    session_question_id = table.Column<Guid>(type: "uuid", nullable: true),
                    role = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    sequence_number = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    metadata = table.Column<string>(type: "jsonb", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_session_messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "session_questions",
                schema: "interview",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    practice_session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: true),
                    prompt = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    asked_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    metadata = table.Column<string>(type: "jsonb", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_session_questions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                schema: "question_bank",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    slug = table.Column<string>(type: "character varying(140)", maxLength: 140, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_skills", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_answers",
                schema: "interview",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    practice_session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    session_question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    answer_text = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    submitted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_answers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_bookmarks",
                schema: "community",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entity_type = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    entity_id = table.Column<Guid>(type: "uuid", nullable: false),
                    notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_bookmarks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_profiles",
                schema: "identity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    display_name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    bio = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    target_role = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: true),
                    experience_level = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    preferred_language = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    skills = table.Column<string[]>(type: "text[]", nullable: false),
                    settings = table.Column<string>(type: "jsonb", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_profiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "identity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: true),
                    username = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    full_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    auth_provider = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    role = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    status = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    is_system_user = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    external_subject = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    last_login_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    settings = table.Column<string>(type: "jsonb", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "question_bank",
                table: "interview_template_questions",
                columns: new[] { "id", "created_at", "deleted_at", "interview_template_id", "is_required", "position", "question_id", "updated_at" },
                values: new object[,]
                {
                    { new Guid("41000000-0000-0000-0000-000000000001"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("40000000-0000-0000-0000-000000000001"), true, 1, new Guid("30000000-0000-0000-0000-000000000001"), null },
                    { new Guid("41000000-0000-0000-0000-000000000002"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("40000000-0000-0000-0000-000000000001"), true, 2, new Guid("30000000-0000-0000-0000-000000000002"), null },
                    { new Guid("41000000-0000-0000-0000-000000000003"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("40000000-0000-0000-0000-000000000001"), false, 3, new Guid("30000000-0000-0000-0000-000000000003"), null }
                });

            migrationBuilder.InsertData(
                schema: "question_bank",
                table: "interview_templates",
                columns: new[] { "id", "created_at", "created_by_user_id", "deleted_at", "description", "difficulty", "is_public", "name", "settings", "slug", "status", "target_role", "updated_at" },
                values: new object[] { new Guid("40000000-0000-0000-0000-000000000001"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000001"), null, "A balanced starter practice session for self-hosted mock interviews.", "Intermediate", true, "General Mock Interview", "{}", "general-mock-interview", "Published", "Software Engineer", null });

            migrationBuilder.InsertData(
                schema: "ai",
                table: "prompt_templates",
                columns: new[] { "id", "created_at", "deleted_at", "description", "is_active", "key", "name", "template_text", "type", "updated_at", "variables", "version" },
                values: new object[,]
                {
                    { new Guid("50000000-0000-0000-0000-000000000001"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Default conversational interviewer prompt.", true, "default_interviewer", "Default Interviewer", "You are a focused mock interviewer helping a user practice. Ask one question at a time.", "Interviewer", null, "{\"variables\":[\"session\",\"question\"]}", 1 },
                    { new Guid("50000000-0000-0000-0000-000000000002"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Default answer scoring prompt.", true, "default_answer_evaluation", "Default Answer Evaluation", "Evaluate the user's answer for relevance, clarity, depth, structure, and communication.", "AnswerEvaluation", null, "{\"variables\":[\"question\",\"answer\"]}", 1 }
                });

            migrationBuilder.InsertData(
                schema: "question_bank",
                table: "question_categories",
                columns: new[] { "id", "created_at", "deleted_at", "description", "name", "parent_category_id", "slug", "sort_order", "updated_at" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Communication, collaboration, and experience questions.", "Behavioral", null, "behavioral", 10, null },
                    { new Guid("10000000-0000-0000-0000-000000000002"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Practical engineering and problem-solving questions.", "Technical", null, "technical", 20, null },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Architecture and tradeoff discussion questions.", "System Design", null, "system-design", 30, null }
                });

            migrationBuilder.InsertData(
                schema: "question_bank",
                table: "question_skills",
                columns: new[] { "id", "created_at", "deleted_at", "question_id", "skill_id", "updated_at", "weight" },
                values: new object[,]
                {
                    { new Guid("31000000-0000-0000-0000-000000000001"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("20000000-0000-0000-0000-000000000001"), null, 3 },
                    { new Guid("31000000-0000-0000-0000-000000000002"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("20000000-0000-0000-0000-000000000002"), null, 3 },
                    { new Guid("31000000-0000-0000-0000-000000000003"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("20000000-0000-0000-0000-000000000003"), null, 3 }
                });

            migrationBuilder.InsertData(
                schema: "question_bank",
                table: "questions",
                columns: new[] { "id", "category_id", "created_at", "created_by_user_id", "deleted_at", "difficulty", "guidance", "is_public", "metadata", "prompt", "title", "type", "updated_at" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000000000001"), new Guid("10000000-0000-0000-0000-000000000001"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000001"), null, "Beginner", null, true, "{}", "Give a concise overview of your background, strengths, and what you are looking to practice.", "Tell me about yourself", "Behavioral", null },
                    { new Guid("30000000-0000-0000-0000-000000000002"), new Guid("10000000-0000-0000-0000-000000000002"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000001"), null, "Intermediate", null, true, "{}", "Walk through a difficult bug, how you isolated it, and what you changed to prevent it from recurring.", "Describe a difficult bug you fixed", "Technical", null },
                    { new Guid("30000000-0000-0000-0000-000000000003"), new Guid("10000000-0000-0000-0000-000000000003"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000001"), null, "Advanced", null, true, "{}", "Design an API that supports mock interview sessions, answer storage, and asynchronous AI evaluation.", "Design a scalable interview practice API", "SystemDesign", null }
                });

            migrationBuilder.InsertData(
                schema: "question_bank",
                table: "skills",
                columns: new[] { "id", "created_at", "deleted_at", "description", "name", "slug", "updated_at" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clear, structured verbal answers.", "Communication", "communication", null },
                    { new Guid("20000000-0000-0000-0000-000000000002"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Debugging, reasoning, and decision-making.", "Problem Solving", "problem-solving", null },
                    { new Guid("20000000-0000-0000-0000-000000000003"), new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Designing reliable and scalable systems.", "System Design", "system-design", null }
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "users",
                columns: new[] { "id", "auth_provider", "created_at", "deleted_at", "email", "external_subject", "full_name", "is_system_user", "last_login_at", "password_hash", "role", "settings", "status", "updated_at", "username" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "None", new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "local@interview-practice.local", null, "Local User", true, null, null, "Admin", "{}", "Active", null, "local" });

            migrationBuilder.CreateIndex(
                name: "ix_answer_evaluation_scores_answer_evaluation_id_type",
                schema: "ai",
                table: "answer_evaluation_scores",
                columns: new[] { "answer_evaluation_id", "type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_answer_evaluations_model_run_id",
                schema: "ai",
                table: "answer_evaluations",
                column: "model_run_id");

            migrationBuilder.CreateIndex(
                name: "ix_answer_evaluations_user_answer_id",
                schema: "ai",
                table: "answer_evaluations",
                column: "user_answer_id");

            migrationBuilder.CreateIndex(
                name: "ix_app_settings_key",
                schema: "system",
                table: "app_settings",
                column: "key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_community_votes_user_id_entity_type_entity_id",
                schema: "community",
                table: "community_votes",
                columns: new[] { "user_id", "entity_type", "entity_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_file_assets_storage_bucket_storage_key",
                schema: "storage",
                table: "file_assets",
                columns: new[] { "storage_bucket", "storage_key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_file_assets_user_id_created_at",
                schema: "storage",
                table: "file_assets",
                columns: new[] { "user_id", "created_at" });

            migrationBuilder.CreateIndex(
                name: "ix_guest_sessions_session_token_hash",
                schema: "identity",
                table: "guest_sessions",
                column: "session_token_hash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_interview_template_questions_interview_template_id_position",
                schema: "question_bank",
                table: "interview_template_questions",
                columns: new[] { "interview_template_id", "position" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_interview_templates_slug",
                schema: "question_bank",
                table: "interview_templates",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_job_descriptions_user_id_created_at",
                schema: "interview",
                table: "job_descriptions",
                columns: new[] { "user_id", "created_at" });

            migrationBuilder.CreateIndex(
                name: "ix_model_runs_practice_session_id",
                schema: "ai",
                table: "model_runs",
                column: "practice_session_id");

            migrationBuilder.CreateIndex(
                name: "ix_model_runs_prompt_template_id",
                schema: "ai",
                table: "model_runs",
                column: "prompt_template_id");

            migrationBuilder.CreateIndex(
                name: "ix_practice_sessions_share_token",
                schema: "interview",
                table: "practice_sessions",
                column: "share_token",
                unique: true,
                filter: "share_token IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_practice_sessions_user_id_created_at",
                schema: "interview",
                table: "practice_sessions",
                columns: new[] { "user_id", "created_at" });

            migrationBuilder.CreateIndex(
                name: "ix_prompt_templates_key",
                schema: "ai",
                table: "prompt_templates",
                column: "key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_question_categories_slug",
                schema: "question_bank",
                table: "question_categories",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_question_skills_question_id_skill_id",
                schema: "question_bank",
                table: "question_skills",
                columns: new[] { "question_id", "skill_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_question_tags_question_id_slug",
                schema: "question_bank",
                table: "question_tags",
                columns: new[] { "question_id", "slug" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_questions_category_id",
                schema: "question_bank",
                table: "questions",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_questions_created_by_user_id",
                schema: "question_bank",
                table: "questions",
                column: "created_by_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_resumes_user_id_created_at",
                schema: "interview",
                table: "resumes",
                columns: new[] { "user_id", "created_at" });

            migrationBuilder.CreateIndex(
                name: "ix_session_evaluations_model_run_id",
                schema: "ai",
                table: "session_evaluations",
                column: "model_run_id");

            migrationBuilder.CreateIndex(
                name: "ix_session_evaluations_practice_session_id",
                schema: "ai",
                table: "session_evaluations",
                column: "practice_session_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_session_messages_practice_session_id_sequence_number",
                schema: "interview",
                table: "session_messages",
                columns: new[] { "practice_session_id", "sequence_number" });

            migrationBuilder.CreateIndex(
                name: "ix_session_questions_practice_session_id_position",
                schema: "interview",
                table: "session_questions",
                columns: new[] { "practice_session_id", "position" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_skills_name",
                schema: "question_bank",
                table: "skills",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_skills_slug",
                schema: "question_bank",
                table: "skills",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_answers_practice_session_id",
                schema: "interview",
                table: "user_answers",
                column: "practice_session_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_answers_session_question_id",
                schema: "interview",
                table: "user_answers",
                column: "session_question_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_bookmarks_user_id_entity_type_entity_id",
                schema: "community",
                table: "user_bookmarks",
                columns: new[] { "user_id", "entity_type", "entity_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_profiles_user_id",
                schema: "identity",
                table: "user_profiles",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                schema: "identity",
                table: "users",
                column: "email",
                unique: true,
                filter: "email IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_users_username",
                schema: "identity",
                table: "users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answer_evaluation_scores",
                schema: "ai");

            migrationBuilder.DropTable(
                name: "answer_evaluations",
                schema: "ai");

            migrationBuilder.DropTable(
                name: "app_settings",
                schema: "system");

            migrationBuilder.DropTable(
                name: "community_votes",
                schema: "community");

            migrationBuilder.DropTable(
                name: "file_assets",
                schema: "storage");

            migrationBuilder.DropTable(
                name: "guest_sessions",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "interview_template_questions",
                schema: "question_bank");

            migrationBuilder.DropTable(
                name: "interview_templates",
                schema: "question_bank");

            migrationBuilder.DropTable(
                name: "job_descriptions",
                schema: "interview");

            migrationBuilder.DropTable(
                name: "model_runs",
                schema: "ai");

            migrationBuilder.DropTable(
                name: "practice_sessions",
                schema: "interview");

            migrationBuilder.DropTable(
                name: "prompt_templates",
                schema: "ai");

            migrationBuilder.DropTable(
                name: "question_categories",
                schema: "question_bank");

            migrationBuilder.DropTable(
                name: "question_skills",
                schema: "question_bank");

            migrationBuilder.DropTable(
                name: "question_tags",
                schema: "question_bank");

            migrationBuilder.DropTable(
                name: "questions",
                schema: "question_bank");

            migrationBuilder.DropTable(
                name: "resumes",
                schema: "interview");

            migrationBuilder.DropTable(
                name: "session_evaluations",
                schema: "ai");

            migrationBuilder.DropTable(
                name: "session_messages",
                schema: "interview");

            migrationBuilder.DropTable(
                name: "session_questions",
                schema: "interview");

            migrationBuilder.DropTable(
                name: "skills",
                schema: "question_bank");

            migrationBuilder.DropTable(
                name: "user_answers",
                schema: "interview");

            migrationBuilder.DropTable(
                name: "user_bookmarks",
                schema: "community");

            migrationBuilder.DropTable(
                name: "user_profiles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "users",
                schema: "identity");
        }
    }
}
