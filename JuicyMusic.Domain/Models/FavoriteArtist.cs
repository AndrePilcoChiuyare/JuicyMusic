namespace JuicyMusic.Domain.Models;

public class FavoriteArtist : Favorite<Artist>
{
    private FavoriteArtist(User user, Artist artist) : base(user, artist) { }
    public static new FavoriteArtist Create(User user, Artist artist) => new FavoriteArtist(user, artist);
}
