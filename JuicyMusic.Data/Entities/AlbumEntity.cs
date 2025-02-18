namespace JuicyMusic.Data.Entities;

internal class AlbumEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // Store as int instead of string to reference AlbumType
    public int TypeId { get; set; }

    public int TotalTracks { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int DurationMs { get; set; }

    public Guid GenreId { get; set; }
    
    public GenreEntity Genre { get; set; }

    public Guid ArtistId { get; set; }

    public ArtistEntity Artist { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public List<TrackEntity> Tracks { get; set; } = new();
    public List<FavoriteAlbumEntity> FavoriteAlbums { get; set; } = new();
}
