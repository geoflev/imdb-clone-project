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
}
