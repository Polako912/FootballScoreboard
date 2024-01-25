using FootballScoreboard.Abstractions;
using FootballScoreboard.Models;

namespace FootballScoreboard.Services;

public class UpdateMatchService
{
    private readonly IFootballMatchRepository _footballMatchRepository;
    
    public UpdateMatchService(IFootballMatchRepository footballMatchRepository)        
    {
        _footballMatchRepository = footballMatchRepository;
    }
}