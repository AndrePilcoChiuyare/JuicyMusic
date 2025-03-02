using JuicyMusic.Data.Entities;
using JuicyMusic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using JuicyMusic.Application.Data.Repository.ArtistRepository;

namespace JuicyMusic.Data.Repository.ArtistRepository;

internal class ArtistRepository(JuicyMusicContext db) : IArtistRepository
{
    public async Task<Artist?> GetArtistById(Guid id)
    {
        var entity = await db.Set<ArtistEntity>()
            .Include(t => t.Genre)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);

        if (entity is null || entity.Genre is null)
            return null;

        var genre = new Genre(entity.GenreId, entity.Genre.Name);

        return new Artist(
            entity.Id,
            entity.Name,
            entity.Description,
            genre,
            entity.ImageUrl
        );
    }

    public async Task Save(Artist artist)
    {
        var entity = await db.Set<ArtistEntity>()
            .FirstOrDefaultAsync(i => i.Id == artist.Id);

        if (entity is null)
        {
            entity = new ArtistEntity
            {
                Id = artist.Id,
                Name = artist.Name,
                Followers = artist.Followers,
                Description = artist.Description,
                GenreId = artist.Genre.Id,
                ImageUrl = artist.ImageUrl
            };
            db.Add(entity);
        }
        else
        {
            entity.Name = artist.Name;
            entity.Followers = artist.Followers;
            entity.Description = artist.Description;
            entity.GenreId = artist.Genre.Id;
            entity.ImageUrl = artist.ImageUrl;
            db.Entry(entity).State = EntityState.Modified;
        }

        await db.SaveChangesAsync();
    }
}
