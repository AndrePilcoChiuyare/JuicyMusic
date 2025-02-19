namespace JuicyMusic.Data.Entities;

internal class FavoriteAlbumEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }

    public Guid AlbumId { get; set; }
    public AlbumEntity Album { get; set; }
}
