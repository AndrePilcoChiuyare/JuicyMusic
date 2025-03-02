using JuicyMusic.Data.Entities;
using JuicyMusic.Domain.Models;
using JuicyMusic.Domain.Records;
using Microsoft.EntityFrameworkCore;
using JuicyMusic.Application.Data.Repository.AlbumRepository;

namespace JuicyMusic.Data.Repository.AlbumRepository;

internal class AlbumRepository(JuicyMusicContext db) : IAlbumRepository
{
    public async Task<Album?> GetAlbumById(Guid id)
    {
        var entity = await db.Set<AlbumEntity>()
            .Include(t => t.Genre)
            .Include(t => t.Artist)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);

        if (entity is null || entity.Genre is null || entity.Artist is null)
             return null;

        var genre = new Genre(entity.GenreId, entity.Genre.Name);
        var artistGenre = new Genre(entity.Artist.GenreId, entity.Artist.Genre.Name);

        var artist = new Artist(entity.ArtistId, entity.Artist.Name, entity.Artist.Description, artistGenre, entity.Artist.ImageUrl);

        var albumType = AlbumType.GetById(entity.TypeId) ?? throw new InvalidOperationException("Invalid album type ID");

        return new Album(
            entity.Id,
            entity.Name,
            albumType,
            entity.TotalTracks,
            entity.ReleaseDate,
            entity.DurationMs,
            genre,
            entity.ImageUrl,
            artist
        );
    }

    public async Task Save(Album album)
    {
        var entity = await db.Set<AlbumEntity>()
            .FirstOrDefaultAsync(i => i.Id == album.Id);

        if (entity is null)
        {
            entity = new AlbumEntity
            {
                Id = album.Id,
                Name = album.Name,
                TypeId = album.Type.Id,
                TotalTracks = album.TotalTracks,
                ReleaseDate = album.ReleaseDate,
                DurationMs = album.DurationMs,
                GenreId = album.Genre.Id,
                ArtistId = album.Artist.Id,
                ImageUrl = album.ImageUrl
            };
            db.Add(entity);
        }
        else
        {
            entity.Name = album.Name;
            entity.TypeId = album.Type.Id;
            entity.TotalTracks = album.TotalTracks;
            entity.ReleaseDate = album.ReleaseDate;
            entity.DurationMs = album.DurationMs;
            entity.GenreId = album.Genre.Id;
            entity.ArtistId = album.Artist.Id;
            entity.ImageUrl = album.ImageUrl;
            db.Entry(entity).State = EntityState.Modified;
        }

        await db.SaveChangesAsync();
    }
}
