using FluentAssertions;
using FootballScoreboard.Abstractions;
using FootballScoreboard.Abstractions.Services;
using FootballScoreboard.Models;
using FootballScoreboard.Services;
using NSubstitute;

namespace FootballScoreboard.Tests;

public class GetMatchesServiceTests
{
    private IGetMatchesService _getMatchesService;

    public GetMatchesServiceTests(IGetMatchesService getMatchesService)
    {
        _getMatchesService = getMatchesService;
    }

    [Fact]
    public void GetMatches_EmptyList_ReturnsEmptyList()
    {
        // Arrange
        var footballMatchRepository = Substitute.For<IFootballMatchRepository>();
        footballMatchRepository.Get().Returns(new List<FootballMatch>());
        _getMatchesService = new GetMatchesService(footballMatchRepository);
        
        // Act
        var result = _getMatchesService.GetMatches();
        
        // Assert
        result.Should().BeEmpty();
    }
}