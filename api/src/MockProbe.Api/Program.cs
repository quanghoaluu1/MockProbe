using MockProbe.Application;
using MockProbe.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var authMode = Environment.GetEnvironmentVariable("AUTH_MODE");
if (!string.IsNullOrWhiteSpace(authMode))
{
    builder.Configuration["Auth:Mode"] = authMode;
}

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Configuration.GetValue("Swagger:Enabled", false))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/", () => Results.Ok(new
{
    name = "MockProbe",
    description = "Self-hostable AI mock interview practice API",
    status = "ready"
}));

app.MapHealthChecks("/health");
app.MapControllers();

app.Run();

public partial class Program;
