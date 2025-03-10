namespace JuicyMusic.Domain.Models;

public class Favorite<T>
{
    internal Favorite(Guid id, User user, T item)
    {
        Id = id;
        User = user ?? throw new ArgumentNullException(nameof(user));
        Item = item ?? throw new ArgumentNullException(nameof(item));
    }

    public static Favorite<T> Create(Guid id, User user, T item)
    {
        return new Favorite<T>(id, user, item);
    }

    public Guid Id { get; private set; }
    public User User { get; private set; }
    public T Item { get; private set; }
}
