using imdb_clone_models.Entities.Enums;
using System;

namespace IMDBClone.Application.Features
{
    public record CategoryDto(
        int Id,
        string Name
    );

    public record ActorDto(
        int Id,
        string FirstName,
        string LastName,
        DateTime BirthDate,
        Gender Gender,
        string Bio,
        int ActingScore
    );

    //TODO
    public record MovieDto(
        int Id,
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
        int Id,
        string Name,
        string Description,
        double Budget,
        int Duration,
        DateTime ReleaseDate
    );
}
