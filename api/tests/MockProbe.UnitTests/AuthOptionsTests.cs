using MockProbe.Application.Configuration;

namespace MockProbe.UnitTests;

public sealed class AuthOptionsTests
{
    [Fact]
    public void DefaultsToSelfHostedAuthMode()
    {
        var options = new AuthOptions();

        Assert.Equal("none", options.Mode);
    }
}
