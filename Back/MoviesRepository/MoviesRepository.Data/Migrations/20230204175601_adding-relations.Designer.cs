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
    [Migration("20230204175601_adding-relations")]
    partial class addingrelations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MoviesRepository.Domain.Ator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Atores");
                });

            modelBuilder.Entity("MoviesRepository.Domain.AtorFilme", b =>
                {
                    b.Property<int>("AtorId")
                        .HasColumnType("int");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.HasKey("AtorId", "FilmeId");

                    b.HasIndex("FilmeId");

                    b.ToTable("AtorFilme");
                });

            modelBuilder.Entity("MoviesRepository.Domain.AtorSerie", b =>
                {
                    b.Property<int>("AtorId")
                        .HasColumnType("int");

                    b.Property<int>("SerieId")
                        .HasColumnType("int");

                    b.HasKey("AtorId", "SerieId");

                    b.HasIndex("SerieId");

                    b.ToTable("AtorSerie");
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

            modelBuilder.Entity("MoviesRepository.Domain.CategoriaFilme", b =>
                {
                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId", "FilmeId");

                    b.HasIndex("FilmeId");

                    b.ToTable("CategoriaFilme");
                });

            modelBuilder.Entity("MoviesRepository.Domain.CategoriaSerie", b =>
                {
                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("SerieId")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId", "SerieId");

                    b.HasIndex("SerieId");

                    b.ToTable("CategoriaSerie");
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

            modelBuilder.Entity("MoviesRepository.Domain.AtorFilme", b =>
                {
                    b.HasOne("MoviesRepository.Domain.Ator", "Ator")
                        .WithMany("AtoresFilmes")
                        .HasForeignKey("AtorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesRepository.Domain.Filme", "Filme")
                        .WithMany("AtoresFilmes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ator");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("MoviesRepository.Domain.AtorSerie", b =>
                {
                    b.HasOne("MoviesRepository.Domain.Ator", "Ator")
                        .WithMany("AtoresSeries")
                        .HasForeignKey("AtorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesRepository.Domain.Serie", "Serie")
                        .WithMany("AtoresSeries")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ator");

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("MoviesRepository.Domain.CategoriaFilme", b =>
                {
                    b.HasOne("MoviesRepository.Domain.Categoria", "Categoria")
                        .WithMany("CategoriasFilmes")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesRepository.Domain.Filme", "Filme")
                        .WithMany("CategoriasFilmes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("MoviesRepository.Domain.CategoriaSerie", b =>
                {
                    b.HasOne("MoviesRepository.Domain.Categoria", "Categoria")
                        .WithMany("CategoriasSeries")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesRepository.Domain.Serie", "Serie")
                        .WithMany("CategoriasSeries")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Serie");
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

            modelBuilder.Entity("MoviesRepository.Domain.Ator", b =>
                {
                    b.Navigation("AtoresFilmes");

                    b.Navigation("AtoresSeries");
                });

            modelBuilder.Entity("MoviesRepository.Domain.Categoria", b =>
                {
                    b.Navigation("CategoriasFilmes");

                    b.Navigation("CategoriasSeries");
                });

            modelBuilder.Entity("MoviesRepository.Domain.Filme", b =>
                {
                    b.Navigation("AtoresFilmes");

                    b.Navigation("CategoriasFilmes");
                });

            modelBuilder.Entity("MoviesRepository.Domain.Serie", b =>
                {
                    b.Navigation("AtoresSeries");

                    b.Navigation("CategoriasSeries");

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
