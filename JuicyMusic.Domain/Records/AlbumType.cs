namespace JuicyMusic.Domain.Records;

public record AlbumType (int id, string name)
{
    public static AlbumType Single { get; } = new(1, "Single");

    public static AlbumType Album { get; } = new(2, "Album");
}