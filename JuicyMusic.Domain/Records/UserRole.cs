namespace JuicyMusic.Domain.Records;

public record UserRole (int id, string name)
{
    public static UserRole User { get; } = new(1, "User");
    public static UserRole Artist { get; } = new(2, "Artist");
    public static UserRole Admin { get; } = new(3, "Admin");
}