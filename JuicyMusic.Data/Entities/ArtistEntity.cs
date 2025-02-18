namespace JuicyMusic.Data.Entities;

internal class ArtistEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Followers { get; set; }

    public string Description { get; set; }

    public Guid GenreId { get; set; }
    
    public GenreEntity Genre { get; set; }

    public string ImageUrl { get; set; }

    public ICollection<TrackEntity> Tracks { get; set; } = new List<TrackEntity>();

    public ICollection<AlbumEntity> Albums { get; set; } = new List<AlbumEntity>();
    
    public ICollection<FavoriteArtistEntity> FavoriteArtists { get; set; } = new List<FavoriteArtistEntity>();
}
