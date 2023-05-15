namespace FootballStats.Api.Results;

public class FootballResult
{
    public DateTime Date { get; set; }
    public string HomeTeam { get; set; } = string.Empty;
    public int HomeGoals { get; set; }
    public string AwayTeam { get; set; } = string.Empty;
    public int AwayGoals { get; set; }
}