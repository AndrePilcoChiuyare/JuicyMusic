namespace JuicyMusic.Domain
{
    public class AlbumGenre
    {
        internal AlbumGenre(Album album, Genre genre)
        {
            Album = album;
            Genre = genre;
        }

        public static AlbumGenre Create(Album album, Genre genre)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));

            if (genre == null)
                throw new ArgumentNullException(nameof(genre));
                
            return new AlbumGenre(album, genre);
        }

        public Album Album { get; private set; }
        
        public Genre Genre { get; private set; }
    }
}