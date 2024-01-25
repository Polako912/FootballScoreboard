using FootballScoreboard.Abstractions;
using FootballScoreboard.Abstractions.Services;
using FootballScoreboard.Models;

namespace FootballScoreboard.Services;

public class CreateMatchService : ICreateMatchService
{
    private readonly IFootballMatchRepository _footballMatchRepository;
    
    public CreateMatchService(IFootballMatchRepository footballMatchRepository)        
    {
        _footballMatchRepository = footballMatchRepository;
    }

    public void CreateMatch(FootballMatch footballMatch)
    {
        
    }
}