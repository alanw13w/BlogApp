﻿// <auto-generated />
using BlogService.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogService.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20250129123003_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BlogService.Models.BlogModel", b =>
                {
                    b.Property<int>("BlogModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BlogModelId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("BlogModelId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("BlogService.Models.PostModel", b =>
                {
                    b.Property<int>("PostModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PostModelId"));

                    b.Property<int>("BlogModelId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DateTime")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserModelId")
                        .HasColumnType("int");

                    b.HasKey("PostModelId");

                    b.HasIndex("BlogModelId");

                    b.HasIndex("UserModelId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BlogService.Models.UserModel", b =>
                {
                    b.Property<int>("UserModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserModelId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserModelId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlogService.Models.PostModel", b =>
                {
                    b.HasOne("BlogService.Models.BlogModel", "BlogModel")
                        .WithMany("PostModels")
                        .HasForeignKey("BlogModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogService.Models.UserModel", "UserModel")
                        .WithMany("PostModels")
                        .HasForeignKey("UserModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlogModel");

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("BlogService.Models.BlogModel", b =>
                {
                    b.Navigation("PostModels");
                });

            modelBuilder.Entity("BlogService.Models.UserModel", b =>
                {
                    b.Navigation("PostModels");
                });
#pragma warning restore 612, 618
        }
    }
}
