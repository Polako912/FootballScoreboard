using FootballScoreboard.Abstractions;
using FootballScoreboard.Models;
using FootballScoreboard.Services;
using NSubstitute;

namespace FootballScoreboard.Tests;

public class CreateMatchServiceTests
{
    [Fact]
    public void CreateMatch_MatchDoesNotExist_MatchIsCreated()
    {
        // Arrange
        var newMatch = FootballMatch.Create(FootballTeam.Create("Portugal"), FootballTeam.Create("Marocco"), 0, 0);
        var repository = Substitute.For<IFootballMatchRepository>();
        repository.Exists(newMatch).Returns(false);
        var service = new CreateMatchService(repository);

        // Act
        service.CreateMatch(newMatch);

        // Assert
        repository.Received().Create(newMatch);
    }

    [Fact]
    public void CreateMatch_MatchExists_ExceptionThrown()
    {
        // Arrange
        var newMatch = FootballMatch.Create(FootballTeam.Create("Portugal"), FootballTeam.Create("Marocco"), 0, 0);
        var repository = Substitute.For<IFootballMatchRepository>();
        repository.Exists(newMatch).Returns(true);
        var service = new CreateMatchService(repository);
        
        // Act
        var action = () => service.CreateMatch(newMatch);
        
        // Assert
        repository.DidNotReceive().Create(newMatch);
        Assert.Throws<InvalidOperationException>(action);
    }
}