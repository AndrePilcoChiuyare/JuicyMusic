using System.IO.Compression;

namespace JuicyMusic.Domain
{
    public class Track
    {
        internal Track(string name, bool isExplicit, int durationMs, Album album)
        {
            Name = name;
            IsExplicit = isExplicit;
            DurationMs = durationMs;
            Album = album;
        }

        public static Track Create(string name, bool isExplicit, int durationMs, Album album)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Track name cannot be empty.");

            if (durationMs <= 0)
                if (durationMs <= 0)
                throw new ArgumentException("Duration (ms) cannot be empty");

            // check if album exists?

            return new Track(name, isExplicit, durationMs, album);
        }

        public string Name { get; private set; }

        public bool IsExplicit { get; private set; }

        public int DurationMs { get; private set; }

        public Album Album { get; private set; }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Track name cannot be empty.");

            if (Name == name)
                return;

            Name = name;
        }

        public void ChangeDurationMs(int durationMs)
        {
            if (durationMs <= 0)
                throw new ArgumentException("Duration (ms) cannot be empty");

            if (DurationMs == durationMs)
                return;

            DurationMs = durationMs;
        }

        public void ToggleIsExplicit()
        {
            IsExplicit = !IsExplicit;
        }
    }
}