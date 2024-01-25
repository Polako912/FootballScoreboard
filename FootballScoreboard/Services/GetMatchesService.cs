using FootballScoreboard.Abstractions;
using FootballScoreboard.Abstractions.Services;
using FootballScoreboard.Models;

namespace FootballScoreboard.Services;

public class GetMatchesService : IGetMatchesService
{
    private readonly IFootballMatchRepository _footballMatchRepository;

    public GetMatchesService(IFootballMatchRepository footballMatchRepository)
    {
        _footballMatchRepository = footballMatchRepository;
    }

    public IEnumerable<FootballMatch> GetMatches()
    {
        var matchesData = _footballMatchRepository.Get();
        return matchesData.OrderByDescending(x => x.AwayTeamScore + x.HomeTeamScore).ThenBy(x => x.StartTime);
    }
}