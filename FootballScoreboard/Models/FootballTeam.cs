namespace FootballScoreboard.Models;

public class FootballTeam
{
    private FootballTeam(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public static FootballTeam Create(string name)
    {
        return new FootballTeam(Guid.NewGuid(), name);
    }
}