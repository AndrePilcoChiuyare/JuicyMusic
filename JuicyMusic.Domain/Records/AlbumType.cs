namespace JuicyMusic.Domain.Records;

public record AlbumType(int Id, string Name)
{
    public static AlbumType Single { get; } = new(1, "Single");
    public static AlbumType Album { get; } = new(2, "Album");

    private static readonly List<AlbumType> AllTypes = new() { Single, Album };

    public static string GetById(int id) => AllTypes.FirstOrDefault(at => at.Id == id)?.Name ?? "Unknown";
}
