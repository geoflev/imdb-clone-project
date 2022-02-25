using imdb_clone_models.Entities.Enums;
using System;

namespace IMDBClone.Application.Features
{
    public record CategoryForm(
        string Name
    );

    public record ActorForm(
        string FirstName,
        string LastName,
        DateTime BirthDate,
        Gender Gender,
        string Bio,
        int ActingScore
    );

    public record ProducerForm(
        string FirstName,
        string LastName,
        DateTime BirthDate,
        Gender Gender,
        string Bio,
        int ProducerScore
    );

    public record MovieForm(
        string Name,
        string Description,
        string[] Tags,
        double Budget,
        int Duration,
        DateTime ReleaseDate,
        string[] ExternalIds,
        MovieCategoryForm[] Categories,
        MovieActorForm[] Actors,
        MovieProducerForm[] Producers
    );

    public record MovieActorForm(
        string Id,
        string Value
    );

    public record MovieProducerForm(
        string Id,
        string Value
    );

    public record MovieCategoryForm(
        string Id,
        string Value
    );
}
