using MockProbe.Application.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MockProbe.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddOptions<AuthOptions>()
            .BindConfiguration(AuthOptions.SectionName)
            .Validate(options => IsSupportedAuthMode(options.Mode), "Auth:Mode must be none, local, or oauth.")
            .ValidateOnStart();

        return services;
    }

    private static bool IsSupportedAuthMode(string? mode)
    {
        return string.Equals(mode, "none", StringComparison.OrdinalIgnoreCase)
            || string.Equals(mode, "local", StringComparison.OrdinalIgnoreCase)
            || string.Equals(mode, "oauth", StringComparison.OrdinalIgnoreCase);
    }
}
