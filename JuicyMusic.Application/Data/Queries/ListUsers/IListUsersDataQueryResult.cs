namespace JuicyMusic.Application.Data.Queries.ListUsers;

public interface IListUsersDataQuery
{
    IQueryable<ListUsersDataQueryResult> Execute();
}
