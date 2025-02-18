namespace JuicyMusic.Data.Entities;

internal class FavoriteAlbumEntity
{
    public Guid Id { get; set; }
    public string User { get; set; }

    public string Album { get; set; }
}
