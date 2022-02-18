using imdb_clone_models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace imdb_clone_models.Configurations
{
    class ActorConfiguration : PersonConfiguration<ActorEntity>
    {
        public override void Configure(EntityTypeBuilder<ActorEntity> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.ActingScore)
                .IsRequired();

            builder
                .HasMany(x => x.Movies)
                .WithOne(x => x.Actor)
                .HasForeignKey(x => x.MovieId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
