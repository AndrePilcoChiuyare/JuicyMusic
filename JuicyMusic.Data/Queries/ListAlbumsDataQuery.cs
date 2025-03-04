using Microsoft.EntityFrameworkCore;
using JuicyMusic.Application.Data.Queries.ListAlbums;
using JuicyMusic.Data.Entities;
using JuicyMusic.Domain.Records;

namespace JuicyMusic.Data.Queries;

internal class ListAlbumsDataQuery(JuicyMusicContext db) : IListAlbumsDataQuery
{
    public IQueryable<ListAlbumsDataQueryResult> Execute()
        => db.Set<AlbumEntity>().AsNoTracking().Select(i => new ListAlbumsDataQueryResult
        {
            Id = i.Id,
            Name = i.Name,
            TypeId = i.TypeId,
            TypeName = AlbumType.GetById(i.TypeId).Name,
            TotalTracks = i.TotalTracks,
            ReleaseDate = i.ReleaseDate,
            DurationMs = i.DurationMs,
            GenreId = i.GenreId,
            GenreName = i.Genre.Name,
            ArtistId = i.ArtistId,
            ArtistName = i.Artist.Name,
            ImageUrl = i.ImageUrl,
        });
}
