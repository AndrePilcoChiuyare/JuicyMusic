namespace JuicyMusic.Domain
{
    public class ArtistGenre
    {
        internal ArtistGenre(Artist artist, Genre genre)
        {
            Artist = artist;
            Genre = genre;
        }

        public static ArtistGenre Create(Artist artist, Genre genre)
        {
            if (artist == null)
                throw new ArgumentNullException(nameof(artist));

            if (genre == null)
                throw new ArgumentNullException(nameof(genre));
                
            return new ArtistGenre(artist, genre);
        }

        public Artist Artist { get; private set; }

        public Genre Genre { get; private set; }
    }
}