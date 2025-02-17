namespace JuicyMusic.Domain.Models;

public class FavoriteAlbum : Favorite<Album>
{
    private FavoriteAlbum(User user, Album album) : base(user, album) { }
    public static new FavoriteAlbum Create(User user, Album album) => new FavoriteAlbum(user, album);
}
