namespace FootballScoreboard.Models;

public class FootballMatch
{
    private FootballMatch(
        string homeTeam,
        string awayTeam)
    {
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        HomeTeamScore = 0;
        AwayTeamScore = 0;
        StartTime = DateTime.Now.ToUniversalTime();
    }

    public string HomeTeam { get; private set; }
    public string AwayTeam { get; private set; }
    public int HomeTeamScore { get; private set; }
    public int AwayTeamScore { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }

    public static FootballMatch Create(
        string homeTeam,
        string awayTeam)
    {
        return new FootballMatch(homeTeam, awayTeam);
    }

    public void EndMatch()
    {
        if (EndTime.HasValue) throw new InvalidOperationException("Match has already ended");

        EndTime = DateTime.Now.ToUniversalTime();
    }

    public void UpdateScore(int homeTeamScore, int awayTeamScore)
    {
        if (EndTime.HasValue) throw new InvalidOperationException("Match has already ended");

        HomeTeamScore = homeTeamScore;
        AwayTeamScore = awayTeamScore;
    }
}