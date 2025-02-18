namespace JuicyMusic.Data.Entities;

internal class GenreEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ICollection<TrackEntity> Tracks { get; set; } = new List<TrackEntity>();
    public ICollection<AlbumEntity> Albums { get; set; } = new List<AlbumEntity>();
}
