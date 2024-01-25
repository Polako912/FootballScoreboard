using FootballScoreboard.Models;

namespace FootballScoreboard.Abstractions.Services;

public interface IGetMatchesService
{
    IEnumerable<FootballMatch> GetMatches();
}