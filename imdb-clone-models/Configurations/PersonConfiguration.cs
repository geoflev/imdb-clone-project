using imdb_clone_models.Entities.Enums;
using IMDBClone.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace imdb_clone_models.Configurations
{
    public class PersonConfiguration<T> : IEntityTypeConfiguration<T> where T : PersonEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.FirstName)
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .IsRequired();

            builder
                .Property(x => x.BirthDate)
                .IsRequired();

            builder
                .Property(x => x.Gender)
                .IsRequired()
                .HasConversion(
                gender => gender.ToString(),
                genderStr => (Gender)Enum.Parse(typeof(Gender), genderStr, true));

            builder
                .Property(x => x.Bio)
                .IsRequired(false);

            builder
                .HasMany(x => x.Images)
                .WithOne()
                .HasForeignKey(x => x.Id)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
