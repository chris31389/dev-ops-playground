using Microsoft.AspNetCore.Mvc;

namespace FootballStats.Api.Results;

[ApiController]
[Route("v1/results")]
public class ResultsController : ControllerBase
{
    private static readonly string[] TeamNames =
    {
        "Arsenal",
        "Aston Villa",
        "Bournemouth",
        "Brentford",
        "Brighton",
        "Chelsea",
        "Crystal Palace",
        "Everton",
        "Fulham",
        "Leeds",
        "Leicester",
        "Liverpool",
        "Manchester City",
        "Manchester United",
        "Newcastle",
        "Nottingham",
        "Southampton",
        "Tottenham",
        "West Ham",
        "Wolves"
    };

    private readonly ILogger<ResultsController> _logger;

    public ResultsController(ILogger<ResultsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("latest")]
    public IEnumerable<FootballResult> Get()
    {
        var stack = new Stack<string>();
        foreach (var teamName in GetInUniqueOrder(TeamNames))
        {
            stack.Push(teamName);
        }

        var loopCount = TeamNames.Length / 2;
        return Enumerable.Range(1, loopCount).Select(index => new FootballResult
            {
                Date = DateTime.Now.AddDays(index),
                HomeTeam = stack.Pop(),
                HomeGoals = Random.Shared.Next(0, 5),
                AwayTeam = stack.Pop(),
                AwayGoals = Random.Shared.Next(0, 5)
            })
            .ToList();
    }

    private static IEnumerable<int> UniqueRandom(int minInclusive, int maxInclusive)
    {
        var candidates = Enumerable.Range(minInclusive, maxInclusive).ToList();

        var rnd = new Random();
        while (candidates.Count > 0)
        {
            var index = rnd.Next(candidates.Count);
            yield return candidates[index];
            candidates.RemoveAt(index);
        }
    }

    private static IEnumerable<string> GetInUniqueOrder(IEnumerable<string> inputList)
    {
        var options = inputList.ToList();
        var rnd = new Random();
        while (options.Count > 0)
        {
            var index = rnd.Next(options.Count);
            yield return options[index];
            options.RemoveAt(index);
        }
    }
}