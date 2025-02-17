using System.IO.Compression;

namespace JuicyMusic.Domain.Models;
public class Track
{
    internal Track(Guid id, string name, int durationMs, Album album, Genre genre, Artist artist, string imageUrl)
    {
        Name = name;
        DurationMs = durationMs;
        Album = album;
        Genre = genre;
        Artist = artist;
        ImageUrl = imageUrl;
        Id = id;
    }

    public static Track Create(Guid id, string name, int durationMs, Album album, Genre genre, Artist artist, string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Track name cannot be empty.");

            if (string.IsNullOrWhiteSpace(imageUrl) || !Uri.IsWellFormedUriString(imageUrl, UriKind.RelativeOrAbsolute))
            throw new ArgumentException("URL is not valid.");

        if (durationMs <= 0)
            throw new ArgumentException("Duration (ms) cannot be empty");

        return new Track(id, name, durationMs, album, genre, artist, imageUrl);
    }

    public string Name { get; private set; }

    public int DurationMs { get; private set; }

    public Album Album { get; private set; }

    public Genre Genre { get; private set; }

    public Artist Artist { get; private set; }

    public string ImageUrl { get; private set; }

    public Guid Id { get; private set; }

    public void ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Track name cannot be empty.");

        if (Name == name)
            return;

        Name = name;
    }

    public void ChangeDurationMs(int durationMs)
    {
        if (durationMs <= 0)
            throw new ArgumentException("Duration (ms) cannot be empty");

        if (DurationMs == durationMs)
            return;

        DurationMs = durationMs;
    }

    public void ChangeUrl(string url)
    {
            if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            throw new ArgumentException("URL is not valid.");

        ImageUrl = url;
    }
}
