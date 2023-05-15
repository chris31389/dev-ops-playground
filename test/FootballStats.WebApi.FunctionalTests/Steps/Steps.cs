using System.Text.Json.Nodes;
using FluentAssertions;
using FootballStats.WebApi.FunctionalTests.Drivers;
using TechTalk.SpecFlow;

namespace FootballStats.WebApi.FunctionalTests.Steps;

[Binding]
public class Steps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly HttpDriver _httpDriver;

    private HttpResponse HttpResponse
    {
        get
        {
            if (_scenarioContext[nameof(HttpResponse)] is not HttpResponse httpResponse)
            {
                throw new ArgumentException($"{nameof(HttpResponse)} has not been set.");
            }

            return httpResponse;
        }
        set => _scenarioContext[nameof(HttpResponse)] = value;
    }

    public Steps(
        ScenarioContext scenarioContext,
        HttpDriver httpDriver)
    {
        _scenarioContext = scenarioContext;
        _httpDriver = httpDriver;
    }

    [When(@"a http GET request is made to the football stats api")]
    public async Task WhenAHttpGetRequestIsMadeToTheFootballStatsApi() => HttpResponse = await _httpDriver.GetLatestResultsAsync();

    [Then(@"the response code should be (.*)")]
    public void ThenTheResponseCodeShouldBe(int statusCode) => HttpResponse.StatusCode.Should().Be(statusCode);

    [Then(@"the response should contain (.*) games")]
    public void ThenTheResponseShouldContainGames(int gameCount)
    {
        var jsonArray = JsonNode.Parse(HttpResponse.Body)!.AsArray();
        jsonArray.Should().HaveCount(gameCount);
    }
}