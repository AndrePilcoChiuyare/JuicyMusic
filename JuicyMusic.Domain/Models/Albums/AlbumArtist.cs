namespace JuicyMusic.Domain
{
    public class AlbumArtist
    {
        internal AlbumArtist(Album album, Artist artist)
        {
            Album = album;
            Artist = artist;
        }

        public static AlbumArtist Create(Album album, Artist artist)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));

            if (artist == null)
                throw new ArgumentNullException(nameof(artist));

            return new AlbumArtist(album, artist);
        }

        public Album Album { get; private set; }
        
        public Artist Artist { get; private set; }
    }
}