﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SweetDictionaryBlogSite.Repository.Context;

#nullable disable

namespace SweetDictionaryBlogSite.Repository.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SweetDictionaryBlogSite.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Category_Name");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Yazılım"
                        });
                });

            modelBuilder.Entity("SweetDictionaryBlogSite.Models.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CommentId");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PostId");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Text");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("SweetDictionaryBlogSite.Models.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PostId");

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint")
                        .HasColumnName("AuthorId");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Content");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts", (string)null);
                });

            modelBuilder.Entity("SweetDictionaryBlogSite.Models.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("UserId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedTime = new DateTime(2024, 10, 22, 21, 7, 47, 91, DateTimeKind.Local).AddTicks(7160),
                            Email = "umut@gmail.com",
                            FirstName = "Umut",
                            LastName = "Ozgenc",
                            Password = "12321321321",
                            Username = "umutozgenc34"
                        });
                });

            modelBuilder.Entity("SweetDictionaryBlogSite.Models.Entities.Comment", b =>
                {
                    b.HasOne("SweetDictionaryBlogSite.Models.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SweetDictionaryBlogSite.Models.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetDictionaryBlogSite.Models.Entities.Post", b =>
                {
                    b.HasOne("SweetDictionaryBlogSite.Models.Entities.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SweetDictionaryBlogSite.Models.Entities.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SweetDictionaryBlogSite.Models.Entities.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("SweetDictionaryBlogSite.Models.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("SweetDictionaryBlogSite.Models.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
