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

        public static ProducerDto ToDto(this ProducerEntity entity)
        {
            return new ProducerDto(
                  entity.Id,
                  entity.FirstName,
                  entity.LastName,
                  entity.BirthDate,
                  entity.Gender,
                  entity.Bio,
                  entity.ProducerScore
                  );
        }

        public static MovieDto ToDto(this MovieEntity entity)
        {
            return new MovieDto(
                  entity.Id,
                  entity.Name,
                  entity.Description,
                  entity.Tags,
                  entity.Budget,
                  entity.Duration,
                  entity.ReleaseDate,
                  entity.ExternalIds,
                  entity.Categories.Select(category => new MovieCategoryDto(category.CategoryId.ToString(), category.CategoryId.ToString())).ToArray()
                  );
        }

        public static MovieEntity FromDto(this MovieEntity entity, MovieForm form)
        {
            entity.Name = form.Name;
            entity.Description = form.Description;
            entity.Tags = form.Tags;
            entity.Budget = form.Budget;
            entity.Duration = form.Duration;
            entity.ReleaseDate = form.ReleaseDate;
            entity.ExternalIds = form.ExternalIds;
            entity.Categories = form.Categories.Select(category => new MovieCategoriesEntity
            {
                CategoryId = category.Id
            }).ToList();
            return entity;
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

        public static ProducerEntity FromDto(this ProducerEntity entity, ProducerForm form)
        {
            entity.FirstName = form.FirstName;
            entity.LastName = form.LastName;
            entity.BirthDate = form.BirthDate;
            entity.ProducerScore = form.ProducerScore;
            entity.Bio = form.Bio;
            entity.Gender = form.Gender;
            return entity;
        }
    }
}
