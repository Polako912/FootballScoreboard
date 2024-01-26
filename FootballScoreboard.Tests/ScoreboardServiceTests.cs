using FootballScoreboard.Services;

namespace FootballScoreboard.Tests;

public class ScoreboardServiceTests
{
    private ScoreboardService _scoreboardService;

    [Fact]
    public void StartNewMatch_MatchDoesNotExist_MatchCreated()
    {
        // Arrange
        _scoreboardService = new ScoreboardService();

        // Act
        _scoreboardService.StartNewMatch("Liverpool", "Manchester United");

        // Assert
        var match = _scoreboardService.GetMatchesSummary().First();
        match.HomeTeam.Name.Should().Be("Liverpool");
        match.AwayTeam.Name.Should().Be("Manchester United");
    }

    [Fact]
    public void StartNewMatch_MatchExists_ExceptionThrown()
    {
        // Arrange
        _scoreboardService = new ScoreboardService();

        // Act
        var action = () => _scoreboardService.StartNewMatch("Liverpool", "Manchester United");

        // Assert
        Assert.Throws<InvalidOperationException>(action);
    }
}