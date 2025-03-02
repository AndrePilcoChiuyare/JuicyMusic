using JuicyMusic.Domain.Models;

namespace JuicyMusic.Application.Data.Repository.GenreRepository;

public interface IGenreRepository
{
    public Task<Genre?> GetGenreById(Guid id);

    public Task Save(Genre genre);
}
