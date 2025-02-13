namespace JuicyMusic.Domain
{
    using JuicyMusic.Domain.Records;
    public class ArtistImage
    {
        internal ArtistImage(Artist artist, int height, int width, string url)
        {
            Artist = artist;
            Height = height;
            Width = width;
            Url = url;
        }

        public static ArtistImage Create(Artist artist, ImageSize imageSize, string url)
        {
            if (artist == null)
                throw new ArgumentNullException(nameof(artist));

            if (imageSize == null)
                throw new ArgumentNullException("Image size cannot be null.");

            if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("URL is not valid.");

            return new ArtistImage(artist, imageSize.size, imageSize.size, url);
        }

        public Artist Artist { get; private set; }

        public int Height { get; private set; }

        public int Width { get; private set; }

        public string Url { get; private set; }

        public void ChangeUrl(string url)
        {
             if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("URL is not valid.");

            Url = url;
        }
    }
}