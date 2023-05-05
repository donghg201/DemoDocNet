﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyPhim.Models;

namespace QuanLyPhim.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230505035558_ChangeFK2")]
    partial class ChangeFK2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuanLyPhim.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("QuanLyPhim.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actor");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Director");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("MovieName");

                    b.Property<string>("MovieStudio");

                    b.Property<string>("PosterMovie");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("MovieId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("QuanLyPhim.Models.Movie", b =>
                {
                    b.HasOne("QuanLyPhim.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
