namespace JuicyMusic.Domain
{
    using JuicyMusic.Domain.Records;
    public class TrackArtist
    {
        internal TrackArtist(Artist artist, Track track, ArtistRole role)
        {
            Artist = artist;
            Track = track;
            Role = role;
        }

        public static TrackArtist Create(Artist artist, Track track, ArtistRole role)
        {
            if (artist == null)
                throw new ArgumentNullException(nameof(artist));

            if (track == null)
                throw new ArgumentNullException(nameof(track));

            if (role == null)
                throw new ArgumentNullException("Artist role cannot be null");
                
            return new TrackArtist(artist, track, role);
        }

        public Artist Artist { get; private set; }

        public Track Track { get; private set; }

        public ArtistRole Role { get; private set; }

        public void ChangeRole(ArtistRole role)
        {
            Role = role;
        }
    }
}