﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecondExam.Repository;

#nullable disable

namespace SecondExam.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220808112924_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SecondExam.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreatedMaterials")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("SecondExam.Entities.EducationalMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TypeId");

                    b.ToTable("EducationalMaterials");
                });

            modelBuilder.Entity("SecondExam.Entities.EducationalMaterialReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DigitReview")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewedMaterialId")
                        .HasColumnType("int");

                    b.Property<string>("TextReview")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReviewedMaterialId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("SecondExam.Entities.EducationalMaterialType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Definition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EducationalMaterialTypes");
                });

            modelBuilder.Entity("SecondExam.Entities.EducationalMaterial", b =>
                {
                    b.HasOne("SecondExam.Entities.Author", "Author")
                        .WithMany("Materials")
                        .HasForeignKey("AuthorId");

                    b.HasOne("SecondExam.Entities.EducationalMaterialType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Author");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("SecondExam.Entities.EducationalMaterialReview", b =>
                {
                    b.HasOne("SecondExam.Entities.EducationalMaterial", "ReviewedMaterial")
                        .WithMany()
                        .HasForeignKey("ReviewedMaterialId");

                    b.Navigation("ReviewedMaterial");
                });

            modelBuilder.Entity("SecondExam.Entities.Author", b =>
                {
                    b.Navigation("Materials");
                });
#pragma warning restore 612, 618
        }
    }
}
