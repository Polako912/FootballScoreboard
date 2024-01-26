using FootballScoreboard.Abstractions;
using FootballScoreboard.Abstractions.Services;
using FootballScoreboard.Models;
using FootballScoreboard.Repositories;

namespace FootballScoreboard.Services;

public class GetMatchesService : IGetMatchesService
{
    public IEnumerable<FootballMatch> GetMatches()
    {
        var matchesData = FootballMatchRepository.MatchesData;
        return matchesData.Where(x => x.EndTime == null).OrderByDescending(x => x.AwayTeamScore + x.HomeTeamScore)
            .ThenBy(x => x.StartTime);
    }
}