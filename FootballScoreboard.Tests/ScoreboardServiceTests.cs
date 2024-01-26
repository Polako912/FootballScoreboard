using FluentAssertions;
using FootballScoreboard.Services;

namespace FootballScoreboard.Tests;

public class ScoreboardServiceTests
{
    private IScoreboardService _scoreboardService;

    [Fact]
    public void StartNewMatch_MatchDoesNotExist_MatchCreated()
    {
        // Arrange
        _scoreboardService = new ScoreboardService();

        // Act
        _scoreboardService.StartNewMatch("Liverpool", "Manchester United");

        // Assert
        var match = _scoreboardService.GetMatchesSummary().First();
        match.HomeTeam.Should().Be("Liverpool");
        match.AwayTeam.Should().Be("Manchester United");
    }

    [Fact]
    public void StartNewMatch_MatchExists_ExceptionThrown()
    {
        // Arrange
        _scoreboardService = new ScoreboardService();
        _scoreboardService.StartNewMatch("Liverpool", "Manchester United");

        // Act
        var action = () => _scoreboardService.StartNewMatch("Liverpool", "Manchester United");

        // Assert
        Assert.Throws<InvalidOperationException>(action);
    }

    [Fact]
    public void StartNewMatch_MatchTeamsNamesAreEmpty_ExceptionThrown()
    {
        // Arrange
        _scoreboardService = new ScoreboardService();

        // Act
        var action = () => _scoreboardService.StartNewMatch("", "");

        // Assert
        Assert.Throws<InvalidOperationException>(action);
    }

    [Fact]
    public void StartNewMatch_MatchTeamsNamesAreNull_ExceptionThrown()
    {
        // Arrange
        _scoreboardService = new ScoreboardService();

        // Act
        var action = () => _scoreboardService.StartNewMatch(null, null);

        // Assert
        Assert.Throws<InvalidOperationException>(action);
    }

    [Fact]
    public void UpdateMatch_MatchDoesNotExist_ExceptionThrown()
    {
        // Arrange
        _scoreboardService = new ScoreboardService();

        // Act
        var action = () => _scoreboardService.UpdateMatch("Liverpool", "Manchester United", 2, 0);

        // Assert
        Assert.Throws<InvalidOperationException>(action);
    }

    [Fact]
    public void UpdateMatch_ScoreIsNegativeNumber_ExceptionThrown()
    {
        // Arrange
        _scoreboardService = new ScoreboardService();
        _scoreboardService.StartNewMatch("Liverpool", "Manchester United");

        // Act
        var action = () => _scoreboardService.UpdateMatch("Liverpool", "Manchester United", -2, -5);

        // Assert
        Assert.Throws<InvalidOperationException>(action);
    }

    [Fact]
    public void UpdateMatch_MatchExists_MatchUpdated()
    {
        // Arrange
        _scoreboardService = new ScoreboardService();
        _scoreboardService.StartNewMatch("Liverpool", "Manchester United");

        // Act
        _scoreboardService.UpdateMatch("Liverpool", "Manchester United", 2, 0);

        // Assert
        var match = _scoreboardService.GetMatchesSummary().First();
        match.HomeTeam.Should().Be("Liverpool");
        match.AwayTeam.Should().Be("Manchester United");
        match.HomeTeamScore.Should().Be(2);
        match.AwayTeamScore.Should().Be(0);
    }

    [Fact]
    public void EndMatch_MatchDoesNotExist_ExceptionThrown()
    {
        // Arrange
        _scoreboardService = new ScoreboardService();

        // Act
        var action = () => _scoreboardService.EndMatch("Liverpool", "Manchester United");

        // Assert
        Assert.Throws<InvalidOperationException>(action);
    }

    [Fact]
    public void EndMatch_MatchExists_MatchEnded()
    {
        // Arrange
        _scoreboardService = new ScoreboardService();
        _scoreboardService.StartNewMatch("Liverpool", "Manchester United");
        _scoreboardService.StartNewMatch("FC Barcelona", "Real Madrid");

        // Act
        _scoreboardService.EndMatch("Liverpool", "Manchester United");

        // Assert
        var match = _scoreboardService.GetMatchesSummary().First();
        match.HomeTeam.Should().Be("FC Barcelona");
        match.AwayTeam.Should().Be("Real Madrid");
    }

    [Fact]
    public void GetMatchesSummary_MatchDoesNotExist_ReturnsEmptyList()
    {
        // Arrange
        _scoreboardService = new ScoreboardService();

        // Act
        var matches = _scoreboardService.GetMatchesSummary();

        // Assert
        matches.Should().BeEmpty();
    }

    [Fact]
    public void GetMatchesSummary_MatchExists_ReturnsMatchesListOrderedByScore()
    {
        // Arrange
        _scoreboardService = new ScoreboardService();
        _scoreboardService.StartNewMatch("Liverpool", "Manchester United");
        _scoreboardService.StartNewMatch("FC Barcelona", "Real Madrid");
        _scoreboardService.UpdateMatch("FC Barcelona", "Real Madrid", 3, 1);
        _scoreboardService.UpdateMatch("Liverpool", "Manchester United", 1, 1);

        // Act
        var matches = _scoreboardService.GetMatchesSummary();

        // Assert
        matches.Should().NotBeEmpty();
        matches.Count.Should().Be(2);
        matches.First().HomeTeam.Should().Be("FC Barcelona");
        matches.First().AwayTeam.Should().Be("Real Madrid");
        matches.Last().HomeTeam.Should().Be("Liverpool");
        matches.Last().AwayTeam.Should().Be("Manchester United");
    }

    [Fact]
    public void GetMatchesSummary_MatchExists_ReturnsMatchesListOrderedByStartTime()
    {
        // Arrange
        _scoreboardService = new ScoreboardService();
        _scoreboardService.StartNewMatch("Liverpool", "Manchester United");
        _scoreboardService.StartNewMatch("FC Barcelona", "Real Madrid");
        _scoreboardService.UpdateMatch("FC Barcelona", "Real Madrid", 3, 1);
        _scoreboardService.UpdateMatch("Liverpool", "Manchester United", 3, 1);

        // Act
        var matches = _scoreboardService.GetMatchesSummary();

        // Assert
        matches.Should().NotBeEmpty();
        matches.Count.Should().Be(2);
        matches.First().HomeTeam.Should().Be("Liverpool");
        matches.First().AwayTeam.Should().Be("Manchester United");
        matches.Last().HomeTeam.Should().Be("FC Barcelona");
        matches.Last().AwayTeam.Should().Be("Real Madrid");
    }
}