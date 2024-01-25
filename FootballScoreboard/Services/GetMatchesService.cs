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
        
    }
}