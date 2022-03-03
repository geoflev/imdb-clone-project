using GMDB.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GMDB.Persistence.Configurations
{
    class MovieCategoriesConfiguration : IEntityTypeConfiguration<MovieCategoriesEntity>
    {
        public void Configure(EntityTypeBuilder<MovieCategoriesEntity> builder)
        {
            builder
                .HasKey(x => new { x.MovieId, x.CategoryId });

            builder
                .HasOne(x => x.Movie)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.MovieId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("MovieCategories");
        }
    }
}
