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
    private IFootballMatchRepository _footballMatchRepository;

    [Fact]
    public void GetMatches_EmptyList_ReturnsEmptyList()
    {
        // Arrange
        _footballMatchRepository = Substitute.For<IFootballMatchRepository>();
        _footballMatchRepository.Get().Returns(new List<FootballMatch>());
        _getMatchesService = new GetMatchesService(_footballMatchRepository);
        
        // Act
        var result = _getMatchesService.GetMatches();
        
        // Assert
        result.Should().BeEmpty();
    }
    
    [Fact]
    public void GetMatches_NotEmptyList_ReturnsListSortedByScore()
    {
        // Arrange
        _footballMatchRepository = Substitute.For<IFootballMatchRepository>();
        _footballMatchRepository.Get().Returns(GetDataWithScores());
        _getMatchesService = new GetMatchesService(_footballMatchRepository);
        
        // Act
        var result = _getMatchesService.GetMatches();
        
        // Assert
        result.Should().NotBeEmpty();
        result.First().HomeTeam.Name.Should().Be("Australia");
        result.Last().HomeTeam.Name.Should().Be("FC Barcelona");
    }
    
    [Fact]
    public void GetMatches_NotEmptyList_ReturnsListSortedByStartDate()
    {
        // Arrange
        _footballMatchRepository = Substitute.For<IFootballMatchRepository>();
        _footballMatchRepository.Get().Returns(GetDataWithScoresAndDates());
        _getMatchesService = new GetMatchesService(_footballMatchRepository);
        
        // Act
        var result = _getMatchesService.GetMatches();
        
        // Assert
        result.Should().NotBeEmpty();
        result.First().HomeTeam.Name.Should().Be("Manchester United");
        result.Last().HomeTeam.Name.Should().Be("Liverpool");
    }
    
    private IEnumerable<FootballMatch> GetDataWithScores()
    {
        return new[]
        {
            FootballMatch.Create(FootballTeam.Create("Liverpool"), FootballTeam.Create("Manchester United"), 2, 0, DateTime.Now.ToUniversalTime()),
            FootballMatch.Create(FootballTeam.Create("FC Barcelona"), FootballTeam.Create("Real Madrid"), 1, 0, DateTime.Now.ToUniversalTime()),
            FootballMatch.Create(FootballTeam.Create("Manchester United"), FootballTeam.Create("Chelsea"), 3, 0, DateTime.Now.ToUniversalTime()),
            FootballMatch.Create(FootballTeam.Create("Mexico"), FootballTeam.Create("Poland"), 4, 0, DateTime.Now.ToUniversalTime()),
            FootballMatch.Create(FootballTeam.Create("France"), FootballTeam.Create("Italy"), 6, 0, DateTime.Now.ToUniversalTime()),
            FootballMatch.Create(FootballTeam.Create("Australia"), FootballTeam.Create("Argentina"), 8, 0, DateTime.Now.ToUniversalTime()),
        };
    }
    
    private IEnumerable<FootballMatch> GetDataWithScoresAndDates()
    {
        return new[]
        {
            FootballMatch.Create(FootballTeam.Create(""), FootballTeam.Create("Manchester United"), 1, 0, DateTime.Now.ToUniversalTime().AddMinutes(50)),
            FootballMatch.Create(FootballTeam.Create("FC Barcelona"), FootballTeam.Create("Real Madrid"), 1, 0, DateTime.Now.ToUniversalTime().AddMinutes(-6)),
            FootballMatch.Create(FootballTeam.Create("Manchester United"), FootballTeam.Create("Chelsea"), 4, 0, DateTime.Now.ToUniversalTime().AddMinutes(-10)),
            FootballMatch.Create(FootballTeam.Create("Mexico"), FootballTeam.Create("Poland"), 4, 0, DateTime.Now.ToUniversalTime().AddMinutes(1)),
            FootballMatch.Create(FootballTeam.Create("France"), FootballTeam.Create("Italy"), 1, 1, DateTime.Now.ToUniversalTime().AddHours(1)),
            FootballMatch.Create(FootballTeam.Create("Australia"), FootballTeam.Create("Argentina"), 1, 2, DateTime.Now.ToUniversalTime()),
        };
    }
}