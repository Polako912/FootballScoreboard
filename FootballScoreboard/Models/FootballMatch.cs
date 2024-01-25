namespace FootballScoreboard.Models;

public class FootballMatch
{
    private FootballMatch(FootballTeam homeTeam, FootballTeam awayTeam, int homeTeamScore, int awayTeamScore, DateTime dateTime)
    {
        HomeTeam = homeTeam;
        AwayTeam = awayTeam;
        HomeTeamScore = homeTeamScore;
        AwayTeamScore = awayTeamScore;
        StartTime = dateTime;
    }

    public FootballTeam HomeTeam { get; private set; }
    public FootballTeam AwayTeam { get; private set; }
    public int HomeTeamScore { get; private set; }
    public int AwayTeamScore { get; private set;}
    public DateTime StartTime { get; private set;}
    public DateTime? EndTime { get; private set;}
    
    public static FootballMatch Create(FootballTeam homeTeam, FootballTeam awayTeam, int homeTeamScore, int awayTeamScore, DateTime dateTime)
    {
        return new FootballMatch(homeTeam, awayTeam, homeTeamScore, awayTeamScore, dateTime);
    }
    
    public void EndMatch()
    {
        if (EndTime.HasValue)
        {
            throw new InvalidOperationException("Match has already ended");
        }
        
        EndTime = DateTime.Now.ToUniversalTime();
    }
    
    public void UpdateScore(int homeTeamScore, int awayTeamScore)
    {
        if (EndTime.HasValue)
        {
            throw new InvalidOperationException("Match has already ended");
        }
        
        HomeTeamScore = homeTeamScore;
        AwayTeamScore = awayTeamScore;
    }
}