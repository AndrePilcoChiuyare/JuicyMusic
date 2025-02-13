namespace JuicyMusic.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        internal User(Guid id, string username, string imageUrl)
        {
            Username = username;
            ImageUrl = imageUrl;
            Id = id;
        }

        public static User Create(Guid id, string username, string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty.");

            if (string.IsNullOrWhiteSpace(imageUrl) || !Uri.IsWellFormedUriString(imageUrl, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("URL is not valid.");

            return new User(id, username, imageUrl);
        }

        public string Username { get; private set; }

        public string ImageUrl { get; private set; }

        public Guid Id { get; private set; }

        public void ChangeName(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty.");

            if (Username == username)
                return;

            Username = username;
        }

        public void ChangeUrl(String url)
        {
             if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("URL is not valid.");

            ImageUrl = url;
        }
    }
}
