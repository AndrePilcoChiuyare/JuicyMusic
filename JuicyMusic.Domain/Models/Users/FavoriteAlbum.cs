namespace JuicyMusic.Domain
{
    public class FavoriteAlbum
    {
        internal FavoriteAlbum(User user, Album album)
        {
            User = user;
            Album = album;
        }

        public static FavoriteAlbum Create(User user, Album album)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (album == null)
                throw new ArgumentNullException(nameof(album));
                
            return new FavoriteAlbum(user, album);
        }

        public User User { get; private set; }

        public Album Album { get; private set; }
    }
}