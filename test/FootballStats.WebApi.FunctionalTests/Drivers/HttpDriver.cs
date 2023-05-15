namespace FootballStats.WebApi.FunctionalTests.Drivers;

public class HttpDriver
{
    private readonly IFootballStatusApi _footballStatusApi;

    public HttpDriver(IFootballStatusApi footballStatusApi)
    {
        _footballStatusApi = footballStatusApi;
    }

    public async Task<HttpResponse> GetLatestResultsAsync()
    {
        var httpResponseMessage = await _footballStatusApi.GetLatest();
        var httpResponse = new HttpResponse
        {
            StatusCode = (int)httpResponseMessage.StatusCode,
            Body = await httpResponseMessage.Content.ReadAsStringAsync()
        };
        return httpResponse;
    }
}