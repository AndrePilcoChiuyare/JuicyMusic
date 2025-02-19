using Microsoft.EntityFrameworkCore;
using JuicyMusic.Application.Data.Queries.ListUsers;
using JuicyMusic.Data.Entities;

namespace JuicyMusic.Data.Queries;

internal class ListUsersDataQuery(JuicyMusicContext db) : IListUsersDataQuery
{
    public IQueryable<ListUsersDataQueryResult> Execute()
        => db.Set<UserEntity>().AsNoTracking().Select(i => new ListUsersDataQueryResult
        {
            Id = i.Id,
            Username = i.Username,
            ImageUrl = i.ImageUrl,
        });
}
