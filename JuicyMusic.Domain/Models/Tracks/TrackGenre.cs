using System.Diagnostics.Contracts;

namespace JuicyMusic.Domain
{
    public class TrackGenre
    {
        internal TrackGenre(Track track, Genre genre)
        {
            Track = track;
            Genre = genre;
        }

        public static TrackGenre Create(Track track, Genre genre)
        {
            if (track == null)
                throw new ArgumentNullException(nameof(track));

            if (genre == null)
                throw new ArgumentNullException(nameof(genre));
                
            return new TrackGenre(track, genre);
        }

        public Track Track { get; private set; }

        public Genre Genre { get; private set; }
    }
}