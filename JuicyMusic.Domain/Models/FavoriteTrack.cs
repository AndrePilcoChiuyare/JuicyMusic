namespace JuicyMusic.Domain.Models;

public class FavoriteTrack : Favorite<Track>
{
    private FavoriteTrack(Guid id, User user, Track track) : base(id, user, track) { }
    public static new FavoriteTrack Create(Guid id, User user, Track track) => new FavoriteTrack(id, user, track);
}
