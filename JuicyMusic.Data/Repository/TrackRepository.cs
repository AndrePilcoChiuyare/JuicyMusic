using JuicyMusic.Data.Entities;
using JuicyMusic.Domain.Models;
using JuicyMusic.Domain.Extensions;

namespace JuicyMusic.Data.Repository;

internal class TrackRepository(JuicyMusicContext db) : ITrackRepository
{
    public async Task<Track?> Get(Guid id)
    {
        var entity = db.Set<TrackEntity>()
            .FirstOrDefault(i => i.Id == id);

        if (entity is null)
            return null;

        return await Task.FromResult(new Track(
            entity.Id,
            entity.Name,
            entity.DurationMs,
            typeof(Album).GetStaticField<Album>(entity.Album),
            typeof(Genre).GetStaticField<Genre>(entity.Genre),
            typeof(Artist).GetStaticField<Artist>(entity.Artist),
            entity.ImageUrl
        ));
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
        entity.Album = track.Album.Name;
        entity.Genre = track.Genre.Name;
        entity.Artist = track.Artist.Name;

        await db.SaveChangesAsync();
    }
}
