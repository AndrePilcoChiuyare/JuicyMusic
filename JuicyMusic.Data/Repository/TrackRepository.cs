using JuicyMusic.Data.Entities;
using JuicyMusic.Domain.Models;
using JuicyMusic.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace JuicyMusic.Data.Repository;

internal class TrackRepository(JuicyMusicContext db) : ITrackRepository
{
       public async Task<Track?> GetTrackById(Guid id)
    {
        var entity = await db.Set<TrackEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);

        if (entity is null)
            return null;

        return new Track(
            entity.Id,
            entity.Name,
            entity.DurationMs,
            typeof(Album).GetStaticField<Album>(entity.Album),
            typeof(Genre).GetStaticField<Genre>(entity.Genre),
            typeof(Artist).GetStaticField<Artist>(entity.Artist),
            entity.ImageUrl
        );
    }

    public async Task Save(Track track)
    {
        var entity = db.Set<TrackEntity>()
            .FirstOrDefault(i => i.Id == track.Id);

        if(entity is null)
        {
            entity = new TrackEntity
            {
                Id = track.Id,
            };
            db.Add(entity);
        }

        entity.Name = track.Name;
        entity.AlbumId = track.Album.Id;
        entity.GenreId = track.Genre.Id;
        entity.ArtistId = track.Artist.Id;
        entity.ImageUrl = track.ImageUrl;

        await db.SaveChangesAsync();
    }
}
