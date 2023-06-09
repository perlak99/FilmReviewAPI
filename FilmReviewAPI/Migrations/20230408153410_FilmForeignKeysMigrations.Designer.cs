﻿// <auto-generated />
using System;
using FilmReviewAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FilmReviewAPI.Migrations
{
    [DbContext(typeof(FilmReviewDbContext))]
    [Migration("20230408153410_FilmForeignKeysMigrations")]
    partial class FilmForeignKeysMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FilmReviewAPI.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int?>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("FilmId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("FilmReviewAPI.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("FilmReviewAPI.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DirectorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("GenreId");

                    b.HasIndex("UserId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("FilmReviewAPI.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("FilmReviewAPI.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("FilmReviewAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = new byte[] { 254, 122, 4, 155, 64, 246, 230, 216, 28, 163, 233, 136, 173, 41, 122, 114, 209, 94, 5, 173, 10, 155, 20, 229, 133, 70, 212, 121, 87, 139, 217, 239, 135, 173, 35, 22, 211, 231, 128, 78, 17, 229, 201, 142, 165, 73, 159, 4, 36, 128, 225, 187, 25, 27, 85, 84, 247, 178, 244, 44, 239, 132, 65, 120 },
                            PasswordSalt = new byte[] { 175, 119, 161, 203, 39, 218, 100, 78, 44, 162, 65, 210, 25, 167, 27, 118, 252, 90, 32, 154, 74, 204, 245, 48, 155, 252, 235, 56, 103, 218, 153, 102, 230, 230, 2, 138, 84, 137, 111, 119, 128, 255, 148, 252, 233, 9, 116, 42, 95, 241, 174, 31, 71, 93, 100, 16, 161, 114, 41, 25, 118, 183, 138, 123, 217, 253, 140, 182, 140, 29, 209, 77, 61, 71, 99, 29, 62, 163, 23, 178, 34, 28, 54, 168, 117, 87, 247, 191, 221, 223, 47, 94, 153, 249, 169, 174, 121, 188, 106, 18, 103, 6, 10, 171, 57, 29, 78, 3, 92, 61, 87, 214, 6, 165, 139, 212, 89, 79, 250, 137, 237, 16, 89, 118, 132, 28, 43, 33 },
                            Username = "Admin"
                        });
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUser", (string)null);

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("FilmReviewAPI.Models.Comment", b =>
                {
                    b.HasOne("FilmReviewAPI.Models.Director", "Director")
                        .WithMany("Comments")
                        .HasForeignKey("DirectorId");

                    b.HasOne("FilmReviewAPI.Models.Film", "Film")
                        .WithMany("Comments")
                        .HasForeignKey("FilmId");

                    b.HasOne("FilmReviewAPI.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");

                    b.Navigation("Film");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FilmReviewAPI.Models.Film", b =>
                {
                    b.HasOne("FilmReviewAPI.Models.Director", "Director")
                        .WithMany("Films")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmReviewAPI.Models.Genre", "Genre")
                        .WithMany("Films")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmReviewAPI.Models.User", null)
                        .WithMany("FavouriteFilms")
                        .HasForeignKey("UserId");

                    b.Navigation("Director");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("FilmReviewAPI.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmReviewAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmReviewAPI.Models.Director", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Films");
                });

            modelBuilder.Entity("FilmReviewAPI.Models.Film", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("FilmReviewAPI.Models.Genre", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("FilmReviewAPI.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FavouriteFilms");
                });
#pragma warning restore 612, 618
        }
    }
}
