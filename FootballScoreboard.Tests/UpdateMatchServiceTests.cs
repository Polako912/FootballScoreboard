using FootballScoreboard.Abstractions;
using FootballScoreboard.Abstractions.Services;
using FootballScoreboard.Models;
using FootballScoreboard.Services;
using NSubstitute;

namespace FootballScoreboard.Tests;

public class UpdateMatchServiceTests
{
    private IUpdateMatchService _updateMatchService;
    private IFootballMatchRepository _footballMatchRepository;

    [Fact]
    public void UpdateMatch_MatchDoesNotExist_ExceptionThrown()
    {
        // Arrange 
        _footballMatchRepository = Substitute.For<IFootballMatchRepository>();
        _updateMatchService = new UpdateMatchService(_footballMatchRepository);

        // Act

        // Assert
    }

    [Fact]
    public void UpdateMatch_MatchExists_MatchUpdated()
    {
        // Arrange
        _footballMatchRepository = Substitute.For<IFootballMatchRepository>();
        _updateMatchService = new UpdateMatchService(_footballMatchRepository);

        // Act 

        // Assert
    }

    private static IEnumerable<FootballMatch> GetDataWithScores()
    {
        return new[]
        {
            FootballMatch.Create(FootballTeam.Create("Liverpool"), FootballTeam.Create("Manchester United"), 2, 0,
                DateTime.Now.ToUniversalTime()),
            FootballMatch.Create(FootballTeam.Create("FC Barcelona"), FootballTeam.Create("Real Madrid"), 1, 0,
                DateTime.Now.ToUniversalTime()),
            FootballMatch.Create(FootballTeam.Create("Manchester United"), FootballTeam.Create("Chelsea"), 3, 0,
                DateTime.Now.ToUniversalTime()),
            FootballMatch.Create(FootballTeam.Create("Mexico"), FootballTeam.Create("Poland"), 4, 0,
                DateTime.Now.ToUniversalTime()),
            FootballMatch.Create(FootballTeam.Create("France"), FootballTeam.Create("Italy"), 6, 0,
                DateTime.Now.ToUniversalTime()),
            FootballMatch.Create(FootballTeam.Create("Australia"), FootballTeam.Create("Argentina"), 8, 0,
                DateTime.Now.ToUniversalTime())
        };
    }
}