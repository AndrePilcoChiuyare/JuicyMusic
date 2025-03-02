using JuicyMusic.Data.Entities;
using JuicyMusic.Domain.Models;
using JuicyMusic.Domain.Records;
using Microsoft.EntityFrameworkCore;
using JuicyMusic.Application.Data.Repository.GenreRepository;

namespace JuicyMusic.Data.Repository.GenreRepository;

internal class GenreRepository(JuicyMusicContext db) : IGenreRepository
{
    public async Task<Genre?> GetGenreById(Guid id)
    {
        var entity = await db.Set<GenreEntity>()
            .FirstOrDefaultAsync(i => i.Id == id);

        if (entity == null)
            return null;

        return new Genre(
            entity.Id,
            entity.Name
        );
    }

    public async Task Save(Genre genre)
    {
        var entity = await db.Set<GenreEntity>()
            .FirstOrDefaultAsync(i => i.Id == genre.Id);

        if (entity is null)
        {
            entity = new GenreEntity
            {
                Id = genre.Id,
                Name = genre.Name
            };
            db.Add(entity);
        }
        else
        {
            entity.Name = genre.Name;
            db.Entry(entity).State = EntityState.Modified;
        }

        await db.SaveChangesAsync();
    }
}
