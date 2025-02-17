namespace JuicyMusic.Domain.Models;

public class FavoriteTrack : Favorite<Track>
{
    private FavoriteTrack(User user, Track track) : base(user, track) { }
    public static new FavoriteTrack Create(User user, Track track) => new FavoriteTrack(user, track);
}
