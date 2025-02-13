namespace JuicyMusic.Domain
{
    using JuicyMusic.Domain.Records;

    public class UserImage
    {
        internal UserImage(User user, int height, int width, string url)
        {
            User = user;
            Height = height;
            Width = width;
            Url = url;
        }

        public static UserImage Create(User user, ImageSize imageSize, string url)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (imageSize == null)
                throw new ArgumentNullException("Image size cannot be null.");
                
            if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("URL is not valid.");

            return new UserImage(user, imageSize.size, imageSize.size, url);
        }

        public User User { get; private set; }

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