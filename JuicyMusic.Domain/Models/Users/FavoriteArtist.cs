namespace JuicyMusic.Domain
{
    public class FavoriteArtist
    {
        internal FavoriteArtist(User user, Artist artist)
        {
            User = user;
            Artist = artist;
        }

        public static FavoriteArtist Create(User user, Artist artist)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (artist == null)
                throw new ArgumentNullException(nameof(artist));
                
            return new FavoriteArtist(user, artist);
        }

        public User User { get; private set; }
        
        public Artist Artist { get; private set; }
    }
}