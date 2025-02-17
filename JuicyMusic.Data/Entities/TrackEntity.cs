namespace JuicyMusic.Data.Entities;

internal class TrackEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int DurationMs { get; set; }

    public string Genre { get; set; }

    public string Album { get; set; }

    public string Artist { get; set; }

    public string ImageUrl { get; set; }
}
