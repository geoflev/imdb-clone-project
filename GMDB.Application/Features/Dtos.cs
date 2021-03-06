using GMDB.Persistence.Entities.Enums;
using System;

namespace GMDB.Application.Features
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
        MovieCategoryDto[] Categories,
        MovieActorDto[] Actors,
        MovieProducerDto[] Producers
    );

    public record MovieDtoLite(
        string Id,
        string Name,
        string Description,
        string[] Tags,
        double Budget,
        int Duration,
        DateTime ReleaseDate,
        string[] ExternalIds,
        string[] Categories,
        string[] Actors,
        string[] Producers
    );

    public record MovieCategoryDto(
           string Id,
           string Name
    );

    public record MovieActorDto(
           string Id,
           string FirstName,
           string LastName
    );

    public record MovieProducerDto(
          string Id,
          string FirstName,
          string LastName
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
