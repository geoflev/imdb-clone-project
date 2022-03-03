using GMDB.Persistence.Entities.Enums;
using System;

namespace GMDB.Application.Features
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
        string[] Categories,
        string[] Actors,
        string[] Producers
    );
}
