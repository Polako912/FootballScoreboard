using FootballScoreboard.Abstractions;

namespace FootballScoreboard.Services;

public class UpdateMatchService
{
    private readonly IFootballMatchRepository _footballMatchRepository;

    public UpdateMatchService(IFootballMatchRepository footballMatchRepository)
    {
        _footballMatchRepository = footballMatchRepository;
    }
}