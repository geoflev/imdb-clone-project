using imdb_clone_models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace imdb_clone_models.Configurations
{
    public class ActorMoviesConfiguration: IEntityTypeConfiguration<ActorMoviesEntity>
    {
        public void Configure(EntityTypeBuilder<ActorMoviesEntity> builder)
        {
            builder
                .HasKey(x => new { x.MovieId, x.ActorId });

            builder
                .HasOne(x => x.Movie)
                .WithMany(x => x.Actors)
                .HasForeignKey(x => x.MovieId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Actor)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.ActorId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("ActorMovies");
        }
    }
}
