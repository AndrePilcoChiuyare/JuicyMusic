namespace JuicyMusic.Domain
{
    using JuicyMusic.Domain.Records;
    public class AlbumImage
    {
        internal AlbumImage(Album album, int height, int width, string url)
        {
            Album = album;
            Height = height;
            Width = width;
            Url = url;
        }

        public static AlbumImage Create(Album album, ImageSize imageSize, string url)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));

            if (imageSize == null)
                throw new ArgumentNullException("Image size cannot be empty");

            if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("URL is not valid.");

            return new AlbumImage(album, imageSize.size, imageSize.size, url);
        }

        public Album Album { get; private set; }

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