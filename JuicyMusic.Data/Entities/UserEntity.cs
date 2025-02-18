namespace JuicyMusic.Data.Entities;

internal class UserEntity
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string ImageUrl { get; set; }

    public ICollection<FavoriteAlbumEntity> FavoriteAlbums { get; set; } = new List<FavoriteAlbumEntity>();

    public ICollection<FavoriteArtistEntity> FavoriteArtists { get; set; } = new List<FavoriteArtistEntity>();

    public ICollection<FavoriteTrackEntity> FavoriteTracks { get; set; } = new List<FavoriteTrackEntity>();
}
