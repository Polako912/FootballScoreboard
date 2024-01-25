using FootballScoreboard.Abstractions;
using FootballScoreboard.Abstractions.Services;

namespace FootballScoreboard.Services;

public class UpdateMatchService : IUpdateMatchService
{
    private readonly IFootballMatchRepository _footballMatchRepository;

    public UpdateMatchService(IFootballMatchRepository footballMatchRepository)
    {
        _footballMatchRepository = footballMatchRepository;
    }
}