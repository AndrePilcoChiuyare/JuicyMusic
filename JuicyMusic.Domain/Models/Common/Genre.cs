namespace JuicyMusic.Domain
{
    public class Genre
    {
        internal Genre(string name)
        {
            Name = name;
        }

        public static Genre Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Genre name cannot be empty");

            return new Genre(name);
        }

        public string Name { get; private set; }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Genre name cannot be empty.");

            if (Name == name)
                return;

            Name = name;
        }
    }
}