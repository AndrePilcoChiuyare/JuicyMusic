namespace JuicyMusic.Data.Entities;

internal class TrackEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int DurationMs { get; set; }

    // Foreign Keys
    public Guid GenreId { get; set; }
    public GenreEntity Genre { get; set; }

    public Guid AlbumId { get; set; }
    public AlbumEntity Album { get; set; }

    public Guid ArtistId { get; set; }
    public ArtistEntity Artist { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public ICollection<FavoriteTrackEntity> FavoriteTracks { get; set; } = new List<FavoriteTrackEntity>();
}