using GMDB.Persistence.Configurations;
using GMDB.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GMDB.Persistence.Configurations
{
    public class ProducerConfiguration : PersonConfiguration<ProducerEntity>
    {
        public override void Configure(EntityTypeBuilder<ProducerEntity> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.ProducerScore)
                .IsRequired();

            builder
                .HasMany(x => x.Movies)
                .WithOne(x => x.Producer)
                .HasForeignKey(x => x.MovieId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
