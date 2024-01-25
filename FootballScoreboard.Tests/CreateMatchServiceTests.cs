using FootballScoreboard.Abstractions;
using FootballScoreboard.Abstractions.Services;
using FootballScoreboard.Models;
using FootballScoreboard.Services;
using NSubstitute;

namespace FootballScoreboard.Tests;

public class CreateMatchServiceTests
{
    private ICreateMatchService _createMatchService;
    private IFootballMatchRepository _footballMatchRepository;

    [Fact]
    public void CreateMatch_MatchDoesNotExist_MatchIsCreated()
    {
        // Arrange
        var newMatch = FootballMatch.Create(FootballTeam.Create("Portugal"), FootballTeam.Create("Marocco"), 0, 0,
            DateTime.Now.ToUniversalTime());
        _footballMatchRepository = Substitute.For<IFootballMatchRepository>();
        _footballMatchRepository.Exists(newMatch).Returns(false);
        _createMatchService = new CreateMatchService(_footballMatchRepository);

        // Act
        _createMatchService.CreateMatch(newMatch);

        // Assert
        _footballMatchRepository.Received().Create(newMatch);
    }

    [Fact]
    public void CreateMatch_MatchExists_ExceptionThrown()
    {
        // Arrange
        var newMatch = FootballMatch.Create(FootballTeam.Create("Portugal"), FootballTeam.Create("Marocco"), 0, 0,
            DateTime.Now.ToUniversalTime());
        _footballMatchRepository = Substitute.For<IFootballMatchRepository>();
        _footballMatchRepository.Exists(newMatch).Returns(true);
        _createMatchService = new CreateMatchService(_footballMatchRepository);

        // Act
        var action = () => _createMatchService.CreateMatch(newMatch);

        // Assert
        _footballMatchRepository.DidNotReceive().Create(newMatch);
        Assert.Throws<InvalidOperationException>(action);
    }
}