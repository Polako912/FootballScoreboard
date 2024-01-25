using FootballScoreboard.Abstractions;
using FootballScoreboard.Models;

namespace FootballScoreboard.Repositories;

public class FootballMatchRepository : IFootballMatchRepository
{
    public void Create(FootballMatch footballMatch)
    {
        GetData().ToList().Add(footballMatch);
    }
    
    public bool Exists(FootballMatch footballMatch)
    {
        return GetData().Any(x => x.HomeTeam.Name == footballMatch.HomeTeam.Name && x.AwayTeam.Name == footballMatch.AwayTeam.Name);
    }
    
    public IEnumerable<FootballMatch> Get()
    {
        return GetData();
    }

    private IEnumerable<FootballMatch> GetData()
    {
        return new[]
        {
            FootballMatch.Create(FootballTeam.Create("Liverpool"), FootballTeam.Create("Manchester United"), 0, 0, DateTime.Now.ToUniversalTime().AddMinutes(1)),
            FootballMatch.Create(FootballTeam.Create("FC Barcelona"), FootballTeam.Create("Real Madrid"), 0, 0, DateTime.Now.ToUniversalTime().AddMinutes(-1)),
            FootballMatch.Create(FootballTeam.Create("Manchester United"), FootballTeam.Create("Chelsea"), 0, 0, DateTime.Now.ToUniversalTime().AddMinutes(2)),
            FootballMatch.Create(FootballTeam.Create("Mexico"), FootballTeam.Create("Poland"), 0, 0, DateTime.Now.ToUniversalTime().AddMinutes(11)),
            FootballMatch.Create(FootballTeam.Create("France"), FootballTeam.Create("Italy"), 0, 0, DateTime.Now.ToUniversalTime().AddMinutes(-5)),
            FootballMatch.Create(FootballTeam.Create("Australia"), FootballTeam.Create("Argentina"), 0, 0, DateTime.Now.ToUniversalTime().AddMinutes(6)),
        };
    }
}