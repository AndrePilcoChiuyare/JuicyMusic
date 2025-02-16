namespace JuicyMusic.Domain
{
    using JuicyMusic.Domain.Records;
    public class Album
    {
        // Private constructor
        internal Album(Guid id, string name, AlbumType type, int totalTracks, DateTime releaseDate, int durationMs, Genre genre, string imageUrl, Artist artist)
        {
            Name = name;
            Type = type;
            TotalTracks = totalTracks;
            ReleaseDate = releaseDate;
            DurationMs = durationMs;
            Genre = genre;
            ImageUrl = imageUrl;
            Artist = artist;
            Id = id;
        }

        public static Album Create(Guid id, string name, AlbumType type, int totalTracks, DateTime releaseDate, int durationMs, Genre genre, string imageUrl, Artist artist)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Album name cannot be empty.");

            if (totalTracks <= 0)
                throw new ArgumentException("Total tracks must be greater than zero.");

            if (durationMs <= 0)
                throw new ArgumentException("Duration (ms) cannot be empty");

            if (type == null)
                throw new ArgumentNullException("Album type cannot be null");

            if (string.IsNullOrWhiteSpace(imageUrl) || !Uri.IsWellFormedUriString(imageUrl, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("URL is not valid.");

            return new Album(id, name, type, totalTracks, releaseDate, durationMs, genre, imageUrl, artist);
        }

        // Properties
        public AlbumType Type { get; private set; }

        public int TotalTracks { get; private set; }

        public string Name { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public int DurationMs { get; private set; }

        public Genre Genre { get; private set; }

        public string ImageUrl { get; private set; }

        public Artist Artist { get; private set; }

        public Guid Id { get; private set; }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Album name cannot be empty.");

            if (Name == name)
                return;

            Name = name;
        }

        public void ChangeTotalTracks(int totalTracks)
        {
            if (totalTracks <= 0)
                throw new ArgumentException("Total tracks must be greater than zero.");

            if (TotalTracks == totalTracks)
                return;

            TotalTracks = totalTracks;
        }

        public void ChangeReleaseDate(DateTime releaseDate)
        {
            if (ReleaseDate == releaseDate)
                return;

            ReleaseDate = releaseDate;
        }

        public void ChangeDurationMs(int durationMs)
        {
            if (durationMs <= 0)
                throw new ArgumentException("Duration (ms) cannot be empty");

            if (DurationMs == durationMs)
                return;

            DurationMs = durationMs;
        }

        public void ChangeImageUrl(String url)
        {
             if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("URL is not valid.");

            ImageUrl = url;
        }
    }
}
