using imdb_clone_models.Entities;
using IMDBClone.Persistence.Entities;
using System;
using System.Linq;

namespace IMDBClone.Application.Features
{
    public static class Mappings
    {
        public static CategoryDto ToDto(this CategoryEntity entity)
        {
            return new CategoryDto(
                  entity.Id,
                  entity.Name);
        }

   

        public static ActorDto ToDto(this ActorEntity entity)
        {
            return new ActorDto(
                  entity.Id,
                  entity.FirstName,
                  entity.LastName,
                  entity.BirthDate,
                  entity.Gender,
                  entity.Bio,
                  entity.ActingScore
                  );
        }

        public static CategoryEntity FromDto(this CategoryEntity entity, CategoryForm form)
        {
            entity.Name = form.Name;
            return entity;
        }

        public static ActorEntity FromDto(this ActorEntity entity, ActorForm form)
        {
            entity.FirstName = form.FirstName;
            entity.LastName = form.LastName;
            entity.BirthDate = form.BirthDate;
            entity.ActingScore = form.ActingScore;
            entity.Bio = form.Bio;
            entity.Gender = form.Gender;
            return entity;
        }
    }
}
