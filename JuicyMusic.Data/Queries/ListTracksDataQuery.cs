using Microsoft.EntityFrameworkCore;
using JuicyMusic.Application.Data.Queries.ListTracks;
using JuicyMusic.Data.Entities;

namespace JuicyMusic.Data.Queries;

internal class ListTracksDataQuery(JuicyMusicContext db) : IListTracksDataQuery
{
    public IQueryable<ListTracksDataQueryResult> Execute()
        => db.Set<TrackEntity>().AsNoTracking().Select(i => new ListTracksDataQueryResult
        {
            Name = i.Name,
            DurationMs = i.DurationMs,
            GenreName = i.Genre.Name,
            AlbumName = i.Album.Name,
            ArtistName = i.Artist.Name,
            ImageUrl = i.ImageUrl,
        });
}
