namespace JuicyMusic.Domain
{
    public class Artist
    {
        internal Artist(Guid id, string name,string description, Genre genre, string imageUrl)
        {
            Name = name;
            Followers = 0;
            Description = description;
            Genre = genre;
            ImageUrl = imageUrl;
            Id = id;
        }

        public static Artist Create(Guid id, string name, string description, Genre genre, string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Artist name cannot be empty.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Artist description cannot be empty.");

            if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("URL is not valid.");

            return new Artist(id, name, description, genre, imageUrl);
        }

        public string Name { get; private set; }

        public int Followers { get; private set; }

        public string Description { get; private set; }

        public Genre Genre { get; private set; }

        public string ImageUrl { get; private set; }

        public Guid id { get; private set; }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Artist description cannot be empty.");

            if (Description == description)
                return;

            Description = description;
        }

        public void AddOneFollower()
        {
            Followers++;
        }

        public void RemoveOneFollower()
        {
            if (Followers > 0)
                Followers--;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException();

            if (Name == name)
                return;

            Name = name;
        }

        public void ChangeImageUrl(string url)
        {
             if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("URL is not valid.");

            ImageUrl = url;
        }
    }
}
