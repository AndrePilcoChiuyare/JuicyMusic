namespace JuicyMusic.Domain.Records;


//? Are records better than enums?
public record ImageSize (int size, string name)
{
    public static ImageSize Small { get; } = new(64, "Small");
    public static ImageSize Medium { get; } = new(300, "Medium");
    public static ImageSize Standard { get; } = new(640, "Standard");
}