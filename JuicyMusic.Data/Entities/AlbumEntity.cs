namespace JuicyMusic.Data.Entities;

internal class AlbumEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public int TotalTracks { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int DurationMs { get; set; }

    public string Genre { get; set; }

    public string ImageUrl { get; set; }
}
