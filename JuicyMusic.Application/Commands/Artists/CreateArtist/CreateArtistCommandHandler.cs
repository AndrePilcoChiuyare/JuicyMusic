using JuicyMusic.Application.Data.Repository.ArtistRepository;
using JuicyMusic.Application.Data.Repository.GenreRepository;
using JuicyMusic.Application.Models.Dto;
using JuicyMusic.Domain.Models;
using MediatR;

namespace JuicyMusic.Application.Commands.Artists;

internal class CreateArtistCommandHandler(
    IArtistRepository artistRepository,
    IGenreRepository genreRepository) : IRequestHandler<CreateArtistCommand, ArtistResponseDto>
{
    public async Task<ArtistResponseDto> Handle(CreateArtistCommand command, CancellationToken cancellationToken)
    {
        Genre genre = await genreRepository.GetGenreById(command.GenreId) ?? throw new InvalidOperationException("Invalid genre ID");

        Artist artist = Artist.Create(
            Guid.NewGuid(),
            command.Name,
            command.Description,
            genre,
            command.ImageUrl
        );

        await artistRepository.Save(artist);

        return new ArtistResponseDto
        {
            Id = artist.Id,
            Name = artist.Name,
            Followers = artist.Followers,
            Description = artist.Description,
            GenreId = artist.Genre.Id,
            GenreName = artist.Genre.Name,
            ImageUrl = artist.ImageUrl
        };
    }
}