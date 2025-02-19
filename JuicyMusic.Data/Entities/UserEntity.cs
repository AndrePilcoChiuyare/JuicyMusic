namespace JuicyMusic.Data.Entities;

internal class UserEntity
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string ImageUrl { get; set; }

    public List<FavoriteAlbumEntity> FavoriteAlbums { get; set; } = new();

    public List<FavoriteArtistEntity> FavoriteArtists { get; set; } = new();

    public List<FavoriteTrackEntity> FavoriteTracks { get; set; } = new();
}
