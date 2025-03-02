using JuicyMusic.Data.Entities;
using JuicyMusic.Domain.Models;
using JuicyMusic.Domain.Records;
using Microsoft.EntityFrameworkCore;
using JuicyMusic.Application.Data.Repository.TrackRepository;

namespace JuicyMusic.Data.Repository.TrackRepository;

internal class TrackRepository(JuicyMusicContext db) : ITrackRepository
{
    public async Task<Track?> GetTrackById(Guid id)
    {
        var entity = await db.Set<TrackEntity>()
            .Include(t => t.Genre)
            .Include(t => t.Artist)
            .ThenInclude(a => a.Genre)
            .Include(t => t.Album)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);

        if (entity is null || entity.Genre is null || entity.Artist is null || entity.Album is null)
            return null;

        var albumGenre = new Genre(entity.GenreId, entity.Genre.Name);
        var artistGenre = new Genre(entity.Artist.GenreId, entity.Artist.Genre.Name);

        var artist = new Artist(entity.ArtistId, entity.Artist.Name, entity.Artist.Description, artistGenre, entity.Artist.ImageUrl);
        var albumType = AlbumType.GetById(entity.Album.TypeId) ?? throw new InvalidOperationException("Invalid album type ID");
        var album = new Album(entity.AlbumId, entity.Album.Name, albumType, entity.Album.TotalTracks, entity.Album.ReleaseDate, entity.Album.DurationMs, albumGenre, entity.Album.ImageUrl, artist);

        return new Track(
            entity.Id,
            entity.Name,
            entity.DurationMs,
            album,
            albumGenre,
            artist,
            entity.ImageUrl
        );
    }

    public async Task Save(Track track)
    {
        var entity = await db.Set<TrackEntity>()
            .FirstOrDefaultAsync(i => i.Id == track.Id);

        if (entity is null)
        {
            entity = new TrackEntity
            {
                Id = track.Id,
                Name = track.Name,
                AlbumId = track.Album.Id,
                GenreId = track.Genre.Id,
                ArtistId = track.Artist.Id,
                ImageUrl = track.ImageUrl
            };
            db.Add(entity);
        }
        else
        {
            entity.Name = track.Name;
            entity.AlbumId = track.Album.Id;
            entity.GenreId = track.Genre.Id;
            entity.ArtistId = track.Artist.Id;
            entity.ImageUrl = track.ImageUrl;
            db.Entry(entity).State = EntityState.Modified;
        }

        await db.SaveChangesAsync();
    }
}
