namespace JuicyMusic.Domain.Models;

public class FavoriteAlbum : Favorite<Album>
{
    private FavoriteAlbum(Guid id, User user, Album album) : base(id, user, album) { }
    public static new FavoriteAlbum Create(Guid id, User user, Album album) => new FavoriteAlbum(id, user, album);
}
