﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesRepository.Data;

#nullable disable

namespace MoviesRepository.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230129192515_fix-db")]
    partial class fixdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AtorFilme", b =>
                {
                    b.Property<int>("AtoresId")
                        .HasColumnType("int");

                    b.Property<int>("FilmesId")
                        .HasColumnType("int");

                    b.HasKey("AtoresId", "FilmesId");

                    b.HasIndex("FilmesId");

                    b.ToTable("AtorFilme");
                });

            modelBuilder.Entity("AtorSerie", b =>
                {
                    b.Property<int>("AtoresId")
                        .HasColumnType("int");

                    b.Property<int>("SeriesId")
                        .HasColumnType("int");

                    b.HasKey("AtoresId", "SeriesId");

                    b.HasIndex("SeriesId");

                    b.ToTable("AtorSerie");
                });

            modelBuilder.Entity("CategoriaFilme", b =>
                {
                    b.Property<int>("CategoriasId")
                        .HasColumnType("int");

                    b.Property<int>("FilmesId")
                        .HasColumnType("int");

                    b.HasKey("CategoriasId", "FilmesId");

                    b.HasIndex("FilmesId");

                    b.ToTable("CategoriaFilme");
                });

            modelBuilder.Entity("CategoriaSerie", b =>
                {
                    b.Property<int>("CategoriasId")
                        .HasColumnType("int");

                    b.Property<int>("SeriesId")
                        .HasColumnType("int");

                    b.HasKey("CategoriasId", "SeriesId");

                    b.HasIndex("SeriesId");

                    b.ToTable("CategoriaSerie");
                });

            modelBuilder.Entity("MoviesRepository.Domain.Ator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Atores");
                });

            modelBuilder.Entity("MoviesRepository.Domain.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("MoviesRepository.Domain.Episodio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Duracao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemporadaId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TemporadaId");

                    b.ToTable("Episodios");
                });

            modelBuilder.Entity("MoviesRepository.Domain.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnoLancamento")
                        .HasColumnType("int");

                    b.Property<string>("CapaUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duracao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sinopse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrailerUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("MoviesRepository.Domain.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnoLancamento")
                        .HasColumnType("int");

                    b.Property<string>("CapaUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sinopse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrailerUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("MoviesRepository.Domain.Temporada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SerieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.ToTable("Temporadas");
                });

            modelBuilder.Entity("AtorFilme", b =>
                {
                    b.HasOne("MoviesRepository.Domain.Ator", null)
                        .WithMany()
                        .HasForeignKey("AtoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesRepository.Domain.Filme", null)
                        .WithMany()
                        .HasForeignKey("FilmesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AtorSerie", b =>
                {
                    b.HasOne("MoviesRepository.Domain.Ator", null)
                        .WithMany()
                        .HasForeignKey("AtoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesRepository.Domain.Serie", null)
                        .WithMany()
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoriaFilme", b =>
                {
                    b.HasOne("MoviesRepository.Domain.Categoria", null)
                        .WithMany()
                        .HasForeignKey("CategoriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesRepository.Domain.Filme", null)
                        .WithMany()
                        .HasForeignKey("FilmesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoriaSerie", b =>
                {
                    b.HasOne("MoviesRepository.Domain.Categoria", null)
                        .WithMany()
                        .HasForeignKey("CategoriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesRepository.Domain.Serie", null)
                        .WithMany()
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesRepository.Domain.Episodio", b =>
                {
                    b.HasOne("MoviesRepository.Domain.Temporada", "Temporada")
                        .WithMany("Episodios")
                        .HasForeignKey("TemporadaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Temporada");
                });

            modelBuilder.Entity("MoviesRepository.Domain.Temporada", b =>
                {
                    b.HasOne("MoviesRepository.Domain.Serie", "Serie")
                        .WithMany("Temporadas")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("MoviesRepository.Domain.Serie", b =>
                {
                    b.Navigation("Temporadas");
                });

            modelBuilder.Entity("MoviesRepository.Domain.Temporada", b =>
                {
                    b.Navigation("Episodios");
                });
#pragma warning restore 612, 618
        }
    }
}
