// <auto-generated />
using System;
using GMDB.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace gmdb_models.Migrations
{
    [DbContext(typeof(GMDBDbContext))]
    [Migration("20220303095648_initAfterRename")]
    partial class initAfterRename
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GMDB.Persistence.Entities.ActorEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ActingScore")
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.ActorMoviesEntity", b =>
                {
                    b.Property<string>("MovieId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("ActorMovies");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.CategoryEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.FileEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MediaType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieEntityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MovieEntityId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MovieEntityId");

                    b.HasIndex("MovieEntityId1");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.MovieCategoriesEntity", b =>
                {
                    b.Property<string>("MovieId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MovieId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("MovieCategories");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.MovieEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Budget")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("ExternalIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieEntityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieEntityId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.ProducerEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProducerScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.ProducerMoviesEntity", b =>
                {
                    b.Property<string>("MovieId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProducerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MovieId", "ProducerId");

                    b.HasIndex("ProducerId");

                    b.ToTable("ProducerMovies");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.ActorMoviesEntity", b =>
                {
                    b.HasOne("GMDB.Persistence.Entities.ActorEntity", "Actor")
                        .WithMany("Movies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GMDB.Persistence.Entities.MovieEntity", "Movie")
                        .WithMany("Actors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.FileEntity", b =>
                {
                    b.HasOne("GMDB.Persistence.Entities.ActorEntity", null)
                        .WithMany("Images")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GMDB.Persistence.Entities.MovieEntity", null)
                        .WithMany("Videos")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GMDB.Persistence.Entities.ProducerEntity", null)
                        .WithMany("Images")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GMDB.Persistence.Entities.MovieEntity", null)
                        .WithMany("Posters")
                        .HasForeignKey("MovieEntityId");

                    b.HasOne("GMDB.Persistence.Entities.MovieEntity", null)
                        .WithMany("Backdrops")
                        .HasForeignKey("MovieEntityId1");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.MovieCategoriesEntity", b =>
                {
                    b.HasOne("GMDB.Persistence.Entities.CategoryEntity", "Category")
                        .WithMany("Movies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GMDB.Persistence.Entities.MovieEntity", "Movie")
                        .WithMany("Categories")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Category");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.MovieEntity", b =>
                {
                    b.HasOne("GMDB.Persistence.Entities.MovieEntity", null)
                        .WithMany("RelatedMovies")
                        .HasForeignKey("MovieEntityId");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.ProducerMoviesEntity", b =>
                {
                    b.HasOne("GMDB.Persistence.Entities.MovieEntity", "Movie")
                        .WithMany("Producers")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GMDB.Persistence.Entities.ProducerEntity", "Producer")
                        .WithMany("Movies")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.ActorEntity", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.MovieEntity", b =>
                {
                    b.Navigation("Actors");

                    b.Navigation("Backdrops");

                    b.Navigation("Categories");

                    b.Navigation("Posters");

                    b.Navigation("Producers");

                    b.Navigation("RelatedMovies");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("GMDB.Persistence.Entities.ProducerEntity", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
