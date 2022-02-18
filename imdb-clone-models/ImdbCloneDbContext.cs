using imdb_clone_models.Entities;
using IMDBClone.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace imdb_clone_models
{
    public class ImdbCloneDbContext : DbContext
    {
        public ImdbCloneDbContext(DbContextOptions<ImdbCloneDbContext> options) : base(options)
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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ImdbCloneDbContext)));
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
