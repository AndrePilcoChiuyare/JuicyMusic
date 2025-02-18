namespace JuicyMusic.Data.Entities;

internal class FavoriteArtistEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }

    public Guid ArtistId { get; set; }
    public ArtistEntity Artist { get; set; }
}
