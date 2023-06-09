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
    [Migration("20230609171206_CommentRepliesMigration")]
    partial class CommentRepliesMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FavouriteFilmUser", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("FavouriteFilmUser");
                });

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

                    b.Property<int?>("ParentCommentId")
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

                    b.HasIndex("ParentCommentId");

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

                    b.Property<int>("AddedByUserId")
                        .HasColumnType("int");

                    b.Property<int?>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddedByUserId");

                    b.HasIndex("DirectorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedByUserId = 1,
                            GenreId = 1,
                            ReleaseYear = 2012,
                            Title = "FilmTest"
                        });
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

            modelBuilder.Entity("FilmReviewAPI.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
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
                            PasswordHash = new byte[] { 187, 76, 160, 41, 10, 250, 36, 251, 49, 2, 176, 99, 15, 226, 240, 204, 201, 23, 223, 228, 168, 74, 42, 169, 76, 51, 235, 113, 64, 87, 56, 241, 33, 1, 121, 31, 155, 189, 121, 40, 12, 51, 49, 173, 74, 8, 171, 48, 163, 149, 45, 19, 179, 162, 58, 159, 82, 18, 194, 10, 9, 154, 155, 163 },
                            PasswordSalt = new byte[] { 140, 120, 236, 29, 60, 107, 30, 210, 156, 45, 137, 214, 9, 194, 101, 153, 44, 74, 24, 252, 101, 199, 221, 18, 242, 3, 70, 216, 79, 239, 219, 53, 126, 220, 153, 64, 51, 40, 64, 43, 229, 239, 151, 153, 63, 105, 192, 55, 144, 160, 213, 72, 71, 59, 96, 171, 100, 226, 188, 78, 86, 143, 220, 19, 104, 94, 237, 214, 25, 20, 89, 236, 156, 169, 184, 76, 43, 121, 17, 8, 4, 88, 127, 29, 29, 112, 26, 228, 9, 17, 4, 6, 251, 215, 196, 249, 91, 36, 172, 253, 58, 105, 249, 14, 81, 253, 140, 10, 80, 159, 179, 214, 236, 110, 166, 165, 229, 125, 135, 51, 223, 102, 178, 89, 177, 12, 34, 228 },
                            Username = "admin"
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

                    b.ToTable("RoleUser");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("FavouriteFilmUser", b =>
                {
                    b.HasOne("FilmReviewAPI.Models.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmReviewAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmReviewAPI.Models.Comment", b =>
                {
                    b.HasOne("FilmReviewAPI.Models.Director", "Director")
                        .WithMany("Comments")
                        .HasForeignKey("DirectorId");

                    b.HasOne("FilmReviewAPI.Models.Film", "Film")
                        .WithMany("Comments")
                        .HasForeignKey("FilmId");

                    b.HasOne("FilmReviewAPI.Models.Comment", "ParentComment")
                        .WithMany("Replies")
                        .HasForeignKey("ParentCommentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FilmReviewAPI.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");

                    b.Navigation("Film");

                    b.Navigation("ParentComment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FilmReviewAPI.Models.Film", b =>
                {
                    b.HasOne("FilmReviewAPI.Models.User", "AddedByUser")
                        .WithMany("AddedFilms")
                        .HasForeignKey("AddedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FilmReviewAPI.Models.Director", "Director")
                        .WithMany("Films")
                        .HasForeignKey("DirectorId");

                    b.HasOne("FilmReviewAPI.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddedByUser");

                    b.Navigation("Director");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("FilmReviewAPI.Models.Rating", b =>
                {
                    b.HasOne("FilmReviewAPI.Models.Film", "Film")
                        .WithMany("Ratings")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmReviewAPI.Models.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("User");
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

            modelBuilder.Entity("FilmReviewAPI.Models.Comment", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("FilmReviewAPI.Models.Director", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Films");
                });

            modelBuilder.Entity("FilmReviewAPI.Models.Film", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("FilmReviewAPI.Models.User", b =>
                {
                    b.Navigation("AddedFilms");

                    b.Navigation("Comments");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
