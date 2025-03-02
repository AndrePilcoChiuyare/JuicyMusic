using JuicyMusic.Domain.Models;

namespace JuicyMusic.Application.Data.Repository.ArtistRepository;

public interface IArtistRepository
{
    public Task<Artist?> GetArtistById(Guid id);

    public Task Save(Artist artist);
}
