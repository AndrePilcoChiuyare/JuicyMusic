namespace JuicyMusic.Domain
{
    using JuicyMusic.Domain.Records;
    public class TrackImage
    {
        internal TrackImage(Track track, int height, int width, string url)
        {
            Track = track;
            Height = height;
            Width = width;
            Url = url;
        }

        public static TrackImage Create(Track track, ImageSize imageSize, string url)
        {
            if (track == null)
                throw new ArgumentNullException(nameof(track));

            if (imageSize == null)
                throw new ArgumentNullException("Image size cannot be null");

            if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("URL is not valid.");

            return new TrackImage(track, imageSize.size, imageSize.size, url);
        }

        public Track Track { get; private set; }

        public int Height { get; private set; }

        public int Width { get; private set; }

        public string Url { get; private set; }

        public void ChangeUrl(String url)
        {
             if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("URL is not valid.");

            Url = url;
        }
    }
}