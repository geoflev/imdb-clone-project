using GMDB.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GMDB.Persistence.Configurations
{
    class MovieConfiguration : IEntityTypeConfiguration<MovieEntity>
    {
        public void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .IsRequired(false);

            builder
               .Property(x => x.Tags)
               .IsRequired(false)
               .HasConversion(
                    tags => tags == null ? null : string.Join(',', tags),
                    tagsStr => string.IsNullOrWhiteSpace(tagsStr) ? null : tagsStr.Split(',', StringSplitOptions.RemoveEmptyEntries));

            builder
                .Property(x => x.Budget)
                .IsRequired();

            builder
                .Property(x => x.Duration)
                .IsRequired();

            builder
                .Property(x => x.ReleaseDate)
                .IsRequired();

            builder
                .Property(x => x.ExternalIds)
                .IsRequired(false)
                .HasConversion(
                ids => ids == null ? null : string.Join(',', ids),
                idsStr => string.IsNullOrWhiteSpace(idsStr)
                ? null
                : idsStr.Split(',', StringSplitOptions.RemoveEmptyEntries));

            builder
                .HasMany(x => x.Categories)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Actors)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Producers)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Posters)
                .WithOne()
                .HasForeignKey(x => x.Id)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Backdrops)
                .WithOne()
                .HasForeignKey(x => x.Id)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Videos)
                .WithOne()
                .HasForeignKey(x => x.Id)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("Movies");
        }
    }
}
