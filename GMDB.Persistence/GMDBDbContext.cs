using GMDB.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace GMDB.Persistence
{
    public class GMDBDbContext : DbContext
    {
        public GMDBDbContext(DbContextOptions<GMDBDbContext> options) : base(options)
        {

        }

        public DbSet<ProducerEntity> Producers { get; set; }
        public DbSet<ActorEntity> Actors { get; set; }
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<FileEntity> Files { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ActorMoviesEntity> ActorMovies { get; set; }
        public DbSet<ProducerMoviesEntity> ProducerMovies { get; set; }
        public DbSet<MovieCategoriesEntity> MovieCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(GMDBDbContext)));
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
