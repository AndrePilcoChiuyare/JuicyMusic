namespace JuicyMusic.Domain.Models;

public class Favorite<T>
{
    internal Favorite(User user, T item)
    {
        User = user ?? throw new ArgumentNullException(nameof(user));
        Item = item ?? throw new ArgumentNullException(nameof(item));
    }

    public static Favorite<T> Create(User user, T item)
    {
        return new Favorite<T>(user, item);
    }

    public User User { get; private set; }
    public T Item { get; private set; }
}
