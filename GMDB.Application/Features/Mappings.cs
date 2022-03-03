using GMDB.Persistence.Entities;
using System.Linq;

namespace GMDB.Application.Features
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

        public static MovieDto ToDto (this MovieEntity entity)
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
                  entity.Categories.Select(category => new MovieCategoryDto(category.CategoryId, category.Category.Name)).ToArray(),
                  entity.Actors.Select(actor => new MovieActorDto(actor.ActorId, actor.Actor.FirstName, actor.Actor.LastName)).ToArray(),
                  entity.Producers.Select(producer => new MovieProducerDto(producer.ProducerId, producer.Producer.FirstName, producer.Producer.LastName)).ToArray()
                  );
        }

        public static MovieDtoLite ToDtoLite(this MovieEntity entity)
        {
            return new MovieDtoLite(
                  entity.Id,
                  entity.Name,
                  entity.Description,
                  entity.Tags,
                  entity.Budget,
                  entity.Duration,
                  entity.ReleaseDate,
                  entity.ExternalIds,
                  entity.Categories.Select(category => category.CategoryId).ToArray(),
                  entity.Actors.Select(actor => actor.ActorId).ToArray(),
                  entity.Producers.Select(producer => producer.ProducerId).ToArray()
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
                CategoryId = category
            }).ToList();
            entity.Actors = form.Actors.Select(actor => new ActorMoviesEntity
            {
                ActorId = actor
            }).ToList();
            entity.Producers = form.Producers.Select(prod => new ProducerMoviesEntity
            {
                ProducerId = prod
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
