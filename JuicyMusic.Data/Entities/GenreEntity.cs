namespace JuicyMusic.Data.Entities;

internal class GenreEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<TrackEntity> Tracks { get; set; } = new();
    public List<AlbumEntity> Albums { get; set; } = new();
}
