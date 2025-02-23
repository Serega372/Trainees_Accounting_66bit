﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TraineesAccounting.Persistence;

#nullable disable

namespace TraineesAccounting.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20250222171224_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TraineesAccounting.Persistence.Entities.InternshipDirectionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("InternshipTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("InternshipDirections");
                });

            modelBuilder.Entity("TraineesAccounting.Persistence.Entities.ProjectEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ProjectTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TraineesAccounting.Persistence.Entities.TraineeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("InternshipDirectionId")
                        .HasColumnType("uuid");

                    b.Property<string>("InternshipTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("ProjectTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("InternshipDirectionId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("TraineesAccounting.Persistence.Entities.TraineeEntity", b =>
                {
                    b.HasOne("TraineesAccounting.Persistence.Entities.InternshipDirectionEntity", "InternshipDirection")
                        .WithMany("Trainees")
                        .HasForeignKey("InternshipDirectionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("TraineesAccounting.Persistence.Entities.ProjectEntity", "Project")
                        .WithMany("Trainees")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("InternshipDirection");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("TraineesAccounting.Persistence.Entities.InternshipDirectionEntity", b =>
                {
                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("TraineesAccounting.Persistence.Entities.ProjectEntity", b =>
                {
                    b.Navigation("Trainees");
                });
#pragma warning restore 612, 618
        }
    }
}
