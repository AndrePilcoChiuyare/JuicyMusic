namespace JuicyMusic.Domain.Models;
public class Genre
{
    internal Genre(Guid id, string name)
    {
        Name = name;
    }

    public static Genre Create(Guid id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Genre name cannot be empty");

        return new Genre(id, name);
    }

    public string Name { get; private set; }

    public Guid Id { get; private set; }

    public void ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Genre name cannot be empty.");

        if (Name == name)
            return;

        Name = name;
    }
}
