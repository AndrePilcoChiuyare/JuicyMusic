namespace JuicyMusic.Data.Entities;

internal class FavoriteTrackEntity
{
    public Guid Id { get; set; }
    public string Track { get; set; }

    public string User { get; set; }
}
