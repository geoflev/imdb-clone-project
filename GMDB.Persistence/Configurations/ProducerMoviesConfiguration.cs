using GMDB.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GMDB.Persistence.Configurations
{
    class ProducerMoviesConfiguration: IEntityTypeConfiguration<ProducerMoviesEntity>
    {
        public void Configure(EntityTypeBuilder<ProducerMoviesEntity> builder)
        {

            builder
                .HasKey(x => new { x.MovieId, x.ProducerId });

            builder
                .HasOne(x => x.Movie)
                .WithMany(x => x.Producers)
                .HasForeignKey(x => x.MovieId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Producer)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.ProducerId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("ProducerMovies");
        }
    }
}
