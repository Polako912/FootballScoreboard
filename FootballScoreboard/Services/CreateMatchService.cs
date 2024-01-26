using FootballScoreboard.Abstractions;
using FootballScoreboard.Abstractions.Services;
using FootballScoreboard.Models;

namespace FootballScoreboard.Services;

public class CreateMatchService : ICreateMatchService
{
    public void CreateMatch(FootballMatch footballMatch)
    {
        if (_footballMatchRepository.Exists(footballMatch)) throw new InvalidOperationException("Match already exists");

        _footballMatchRepository.Create(footballMatch);
    }
}