﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using imdb_clone_models;

namespace imdb_clone_models.Migrations
{
    [DbContext(typeof(ImdbCloneDbContext))]
    partial class ImdbCloneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IMDBClone.Persistence.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("IMDBClone.Persistence.Entities.FileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MediaType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MovieEntityId")
                        .HasColumnType("int");

                    b.Property<int?>("MovieEntityId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieEntityId");

                    b.HasIndex("MovieEntityId1");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("IMDBClone.Persistence.Entities.MovieEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Budget")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("ExternalIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MovieEntityId")
                        .HasColumnType("int");

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

            modelBuilder.Entity("imdb_clone_models.Entities.ActorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("imdb_clone_models.Entities.ActorMoviesEntity", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("ActorMovies");
                });

            modelBuilder.Entity("imdb_clone_models.Entities.MovieCategoriesEntity", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("MovieCategories");
                });

            modelBuilder.Entity("imdb_clone_models.Entities.ProducerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("imdb_clone_models.Entities.ProducerMoviesEntity", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "ProducerId");

                    b.HasIndex("ProducerId");

                    b.ToTable("ProducerMovies");
                });

            modelBuilder.Entity("IMDBClone.Persistence.Entities.FileEntity", b =>
                {
                    b.HasOne("IMDBClone.Persistence.Entities.MovieEntity", null)
                        .WithMany("Videos")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("imdb_clone_models.Entities.ActorEntity", null)
                        .WithMany("Images")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("imdb_clone_models.Entities.ProducerEntity", null)
                        .WithMany("Images")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IMDBClone.Persistence.Entities.MovieEntity", null)
                        .WithMany("Posters")
                        .HasForeignKey("MovieEntityId");

                    b.HasOne("IMDBClone.Persistence.Entities.MovieEntity", null)
                        .WithMany("Backdrops")
                        .HasForeignKey("MovieEntityId1");
                });

            modelBuilder.Entity("IMDBClone.Persistence.Entities.MovieEntity", b =>
                {
                    b.HasOne("IMDBClone.Persistence.Entities.MovieEntity", null)
                        .WithMany("RelatedMovies")
                        .HasForeignKey("MovieEntityId");
                });

            modelBuilder.Entity("imdb_clone_models.Entities.ActorMoviesEntity", b =>
                {
                    b.HasOne("imdb_clone_models.Entities.ActorEntity", "Actor")
                        .WithMany("Movies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMDBClone.Persistence.Entities.MovieEntity", "Movie")
                        .WithMany("Actors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("imdb_clone_models.Entities.MovieCategoriesEntity", b =>
                {
                    b.HasOne("IMDBClone.Persistence.Entities.CategoryEntity", "Category")
                        .WithMany("Movies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMDBClone.Persistence.Entities.MovieEntity", "Movie")
                        .WithMany("Categories")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("imdb_clone_models.Entities.ProducerMoviesEntity", b =>
                {
                    b.HasOne("IMDBClone.Persistence.Entities.MovieEntity", "Movie")
                        .WithMany("Producers")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("imdb_clone_models.Entities.ProducerEntity", "Producer")
                        .WithMany("Movies")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("IMDBClone.Persistence.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("IMDBClone.Persistence.Entities.MovieEntity", b =>
                {
                    b.Navigation("Actors");

                    b.Navigation("Backdrops");

                    b.Navigation("Categories");

                    b.Navigation("Posters");

                    b.Navigation("Producers");

                    b.Navigation("RelatedMovies");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("imdb_clone_models.Entities.ActorEntity", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("imdb_clone_models.Entities.ProducerEntity", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
