using JuicyMusic.Domain.Models;

namespace JuicyMusic.Application.Data.Repository.AlbumRepository;

public interface IAlbumRepository
{
    public Task<Album?> GetAlbumById(Guid id);

    public Task Save(Album album);
}
