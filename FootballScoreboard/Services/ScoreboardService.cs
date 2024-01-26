using FootballScoreboard.Models;

namespace FootballScoreboard.Services;

public class ScoreboardService : IScoreboardService
{
    private List<FootballMatch> Matches { get; } = new();

    public void StartNewMatch(string homeTeam, string awayTeam)
    {
        if (Matches.Exists(x => x.HomeTeam == homeTeam && x.AwayTeam == awayTeam))
            throw new InvalidOperationException("Match already exist");

        Matches.Add(FootballMatch.Create(homeTeam, awayTeam));
    }

    public void UpdateMatch(string homeTeam, string awayTeam, int homeScore, int awayScore)
    {
        if (homeScore < 0 || awayScore < 0)
            throw new InvalidOperationException("Scores must be greater than 0");

        if (!Matches.Exists(x => x.HomeTeam == homeTeam && x.AwayTeam == awayTeam))
            throw new InvalidOperationException("Match does not exist");

        var match = Matches.First(x => x.HomeTeam == homeTeam && x.AwayTeam == awayTeam);
        match.UpdateScore(homeScore, awayScore);
    }

    public void EndMatch(string homeTeam, string awayTeam)
    {
        if (!Matches.Exists(x => x.HomeTeam == homeTeam && x.AwayTeam == awayTeam))
            throw new InvalidOperationException("Match does not exist");

        var match = Matches.First(x => x.HomeTeam == homeTeam && x.AwayTeam == awayTeam);
        match.EndMatch();
    }

    public List<FootballMatch> GetMatchesSummary()
    {
        return Matches.Where(x => x.EndTime == null).OrderByDescending(x => x.AwayTeamScore + x.HomeTeamScore)
            .ThenBy(x => x.StartTime).ToList();
    }
}