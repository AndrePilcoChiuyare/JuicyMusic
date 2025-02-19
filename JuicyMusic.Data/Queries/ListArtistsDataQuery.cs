using Microsoft.EntityFrameworkCore;
using JuicyMusic.Application.Data.Queries.ListArtists;
using JuicyMusic.Data.Entities;
using JuicyMusic.Domain.Records;

namespace JuicyMusic.Data.Queries;

internal class ListArtistsDataQuery(JuicyMusicContext db) : IListArtistsDataQuery
{
    public IQueryable<ListArtistsDataQueryResult> Execute()
        => db.Set<ArtistEntity>().AsNoTracking().Select(i => new ListArtistsDataQueryResult
        {
            Id = i.Id,
            Name = i.Name,
            Followers = i.Followers,
            Description = i.Description,
            GenreName = i.Genre.Name,
            ImageUrl = i.ImageUrl,
        });
}
