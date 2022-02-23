using imdb_clone_models.Entities.Enums;
using System;

namespace IMDBClone.Application.Features
{
    public record CategoryDto(
        string Id,
        string Name
    );

    public record ActorDto(
        string Id,
        string FirstName,
        string LastName,
        DateTime BirthDate,
        Gender Gender,
        string Bio,
        int ActingScore
    );

    public record ProducerDto(
        string Id,
        string FirstName,
        string LastName,
        DateTime BirthDate,
        Gender Gender,
        string Bio,
        int ProducerScore
    );

    //TODO
    public record MovieDto(
        string Id,
        string Name,
        string Description,
        string[] Tags,
        double Budget,
        int Duration,
        DateTime ReleaseDate,
        string[] ExternalIds,
        MovieCategoryDto[] Categories
        );

    public record MovieCategoryDto(
           string Id,
           string Value
        );

    public record MovieLiteDto(
        string Id,
        string Name,
        string Description,
        double Budget,
        int Duration,
        DateTime ReleaseDate
    );
}
