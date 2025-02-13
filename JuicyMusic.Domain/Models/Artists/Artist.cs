namespace JuicyMusic.Domain
{
    public class Artist
    {
        internal Artist(string name,string description) 
        {
            Name = name;
            Followers = 0;
            Description = description;
        }

        public static Artist Create(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Artist name cannot be empty.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Artist description cannot be empty.");

            return new Artist(name, description);
        }

        public string Name { get; private set; }

        public int Followers { get; private set; }

        public string Description { get; private set; }

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
    }
}
