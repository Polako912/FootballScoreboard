using FootballScoreboard.Models;

namespace FootballScoreboard.Abstractions.Services;

public interface ICreateMatchService
{
    void CreateMatch(FootballMatch footballMatch);
}