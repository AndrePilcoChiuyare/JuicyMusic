using JuicyMusic.Application.Data.Repository.AlbumRepository;
using JuicyMusic.Application.Data.Repository.ArtistRepository;
using JuicyMusic.Application.Data.Repository.GenreRepository;
using JuicyMusic.Application.Models.Dto;
using JuicyMusic.Domain.Models;
using JuicyMusic.Domain.Records;
using MediatR;

namespace JuicyMusic.Application.Commands.Albums;

internal class CreateAlbumCommandHandler(
    IAlbumRepository albumRepository,
    IArtistRepository artistRepository,
    IGenreRepository genreRepository) : IRequestHandler<CreateAlbumCommand, AlbumResponseDto>
{
    public async Task<AlbumResponseDto> Handle(CreateAlbumCommand command, CancellationToken cancellationToken)
    {
        AlbumType albumType = AlbumType.GetById(command.TypeId) ?? throw new InvalidOperationException("Invalid album type ID");
        Genre genre = await genreRepository.GetGenreById(command.GenreId) ?? throw new InvalidOperationException("Invalid genre ID");
        Artist artist = await artistRepository.GetArtistById(command.ArtistId) ?? throw new InvalidOperationException("Invalid artist ID");

        DateTime? releaseDate = command.ReleaseDate;
        if (releaseDate is null)
            releaseDate = DateTime.Now;

        Album album = Album.Create(
            Guid.NewGuid(),
            command.Name,
            albumType,
            command.TotalTracks,
            releaseDate.Value,
            command.DurationMs,
            genre,
            command.ImageUrl,
            artist
        );

        await albumRepository.Save(album);

        return new AlbumResponseDto
        {
            Id = album.Id,
            Name = album.Name,
            TypeId = album.Type.Id,
            TypeName = album.Type.Name,
            TotalTracks = album.TotalTracks,
            ReleaseDate = album.ReleaseDate,
            DurationMs = album.DurationMs,
            GenreId = album.Genre.Id,
            GenreName = album.Genre.Name,
            ArtistId = album.Artist.Id,
            ArtistName = album.Artist.Name,
            ImageUrl = album.ImageUrl
        };
    }
}
