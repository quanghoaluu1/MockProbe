namespace MockProbe.IntegrationTests;

public sealed class ApiSmokeTests
{
    [Fact]
    public void ApiAssemblyExposesProgramType()
    {
        Assert.Equal("Program", typeof(Program).Name);
    }
}
