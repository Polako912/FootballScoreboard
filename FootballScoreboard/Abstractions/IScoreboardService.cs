using FootballScoreboard.Models;

namespace FootballScoreboard.Services;

public interface IScoreboardService
{
    void StartNewMatch(string homeTeam, string awayTeam);
    void UpdateMatch(string homeTeam, string awayTeam, int homeScore, int awayScore);
    void EndMatch(string homeTeam, string awayTeam);
    List<FootballMatch> GetMatchesSummary();
}