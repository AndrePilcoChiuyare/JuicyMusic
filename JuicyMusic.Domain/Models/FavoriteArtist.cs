namespace JuicyMusic.Domain.Models;

public class FavoriteArtist : Favorite<Artist>
{
    private FavoriteArtist(Guid id, User user, Artist artist) : base(id, user, artist) { }
    public static new FavoriteArtist Create(Guid id, User user, Artist artist) => new FavoriteArtist(id, user, artist);
}
