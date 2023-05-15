namespace FootballStats.WebApi.FunctionalTests.Drivers;

public class HttpResponse
{
    public int StatusCode { get; set; }
    public string Body { get; set; } = string.Empty;
}