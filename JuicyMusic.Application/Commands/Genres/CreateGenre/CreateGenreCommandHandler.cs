using JuicyMusic.Application.Data.Repository.GenreRepository;
using JuicyMusic.Application.Models.Dto;
using JuicyMusic.Domain.Models;
using MediatR;

namespace JuicyMusic.Application.Commands.Genres;

internal class CreateGenreCommandHandler(
    IGenreRepository genreRepository) : IRequestHandler<CreateGenreCommand, GenreResponseDto>
{
    public async Task<GenreResponseDto> Handle(CreateGenreCommand command, CancellationToken cancellationToken)
    {
        Genre genre = Genre.Create(
            Guid.NewGuid(),
            command.Name
        );

        await genreRepository.Save(genre);

        return new GenreResponseDto
        {
            Id = genre.Id,
            Name = genre.Name,
        };
    }
}
