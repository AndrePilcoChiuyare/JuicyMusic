namespace JuicyMusic.Domain.Records;

public record ArtistRole (int id, string name)
{
    public static ArtistRole Main { get; } = new(1, "Main");
    public static ArtistRole Featured { get; } = new(2, "Featured");
}