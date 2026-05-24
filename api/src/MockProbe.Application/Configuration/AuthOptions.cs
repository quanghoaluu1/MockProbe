namespace MockProbe.Application.Configuration;

public sealed class AuthOptions
{
    public const string SectionName = "Auth";

    public string Mode { get; init; } = "none";
}
