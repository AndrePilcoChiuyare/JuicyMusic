using Microsoft.EntityFrameworkCore;
using JuicyMusic.Application.Data.Queries.ListTracks;
using JuicyMusic.Data.Entities;

namespace JuicyMusic.Data.Queries;

internal class ListTracksDataQuery(JuicyMusicContext db) : IListTracksDataQuery
{
    public IQueryable<ListTracksDataQueryResult> Execute()
        => db.Set<TrackEntity>().AsNoTracking().Select(i => new ListTracksDataQueryResult
        {
            Id = i.Id,
            Name = i.Name,
            DurationMs = i.DurationMs,
            GenreId = i.GenreId,
            GenreName = i.Genre.Name,
            AlbumId = i.AlbumId,
            AlbumName = i.Album.Name,
            ArtistId = i.ArtistId,
            ArtistName = i.Artist.Name,
            ImageUrl = i.ImageUrl,
        });
}
