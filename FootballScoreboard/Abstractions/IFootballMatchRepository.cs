using FootballScoreboard.Models;

namespace FootballScoreboard.Abstractions;

public interface IFootballMatchRepository
{
    void Create(FootballMatch footballMatch);

    bool Exists(FootballMatch footballMatch);

    IEnumerable<FootballMatch> Get();
}