namespace JuicyMusic.Data.Entities;

internal class FavoriteTrackEntity
{
    public Guid Id { get; set; }

    public Guid TrackId { get; set; }
    public TrackEntity Track { get; set; }

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
}
