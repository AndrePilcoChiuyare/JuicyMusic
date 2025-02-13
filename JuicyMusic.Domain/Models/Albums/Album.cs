namespace JuicyMusic.Domain
{
    using JuicyMusic.Domain.Records;
    public class Album
    {
        // Private constructor
        internal Album(string name, AlbumType type, int totalTracks, DateTime releaseDate, int durationMs)
        {
            //? Do we need an Id? YES
            Name = name;
            Type = type;
            TotalTracks = totalTracks;
            ReleaseDate = releaseDate;
            DurationMs = durationMs;
        }

        public static Album Create(string name, AlbumType type, int totalTracks, DateTime releaseDate, int durationMs)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Album name cannot be empty.");

            if (totalTracks <= 0)
                throw new ArgumentException("Total tracks must be greater than zero.");

            if (durationMs <= 0)
                throw new ArgumentException("Duration (ms) cannot be empty");

            if (type == null)
                throw new ArgumentNullException("Album type cannot be null");

            return new Album(name, type, totalTracks, releaseDate, durationMs);
        }

        // Properties
        public AlbumType Type { get; private set; }

        public int TotalTracks { get; private set; }

        public string Name { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public int DurationMs { get; private set; }

        //? Are these needed?

        private readonly List<AlbumArtist> _albumArtists = new();

        public IReadOnlyCollection<AlbumArtist> AlbumArtists => _albumArtists.AsReadOnly();

        // private readonly List<AlbumGenre> _albumGenres = new();

        // public IReadOnlyCollection<AlbumGenre> AlbumGenres => _albumGenres.AsReadOnly();

        // private readonly List<AlbumImage> _albumImages = new();

        // public IReadOnlyCollection<AlbumImage> AlbumImages => _albumImages.AsReadOnly();

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

        //? Are these needed?

        // public void AddArtist(Artist artist)
        // {
        //     _albumArtists.Add(AlbumArtist.Create(this, artist));
        // }

        // public void AddGenre(Genre genre)
        // {
        //     _albumGenres.Add(AlbumGenre.Create(this, genre));
        // }

        // public void AddImage(ImageSize imageSize, string url)
        // {
        //     _albumImages.Add(AlbumImage.Create(this, imageSize, url));
        // }
    }
}