using Microsoft.EntityFrameworkCore;
using JuicyMusic.Application.Data.Queries.ListGenres;
using JuicyMusic.Data.Entities;

namespace JuicyMusic.Data.Queries;

internal class ListGenresDataQuery(JuicyMusicContext db) : IListGenresDataQuery
{
    public IQueryable<ListGenresDataQueryResult> Execute()
        => db.Set<GenreEntity>().AsNoTracking().Select(i => new ListGenresDataQueryResult
        {
            Id = i.Id,
            GenreName = i.Name
        });
}
