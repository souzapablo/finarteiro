namespace Finarteiro.FunctionalTests;
public class BaseFunctionalTest(FunctionalTestWebAppFactory factory) : IClassFixture<FunctionalTestWebAppFactory>
{
    public HttpClient HttpClient { get; init; } = factory.CreateClient();
}
