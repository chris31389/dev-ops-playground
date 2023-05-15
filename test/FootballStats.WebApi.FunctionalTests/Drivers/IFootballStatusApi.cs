using Refit;

namespace FootballStats.WebApi.FunctionalTests.Drivers;

public interface IFootballStatusApi
{
    [Get("/v1/results/latest")]
    Task<HttpResponseMessage> GetLatest();
}