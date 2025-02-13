namespace JuicyMusic.Domain
{
    public class FavoriteTrack
    {
        internal FavoriteTrack(User user, Track track)
        {
            User = user;
            Track = track;
        }

        public static FavoriteTrack Create(User user, Track track)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (track == null)
                throw new ArgumentNullException(nameof(track));

            return new FavoriteTrack(user, track);
        }

        public User User { get; private set; }

        public Track Track { get; private set; }
    }
}