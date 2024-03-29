﻿// <auto-generated />
using System;
using FitDash.Workout.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FitDash.Workout.Data.Migrations
{
    [DbContext(typeof(WorkoutContext))]
    [Migration("20221026004409_Removed_entity_User")]
    partial class Removed_entity_User
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ExerciseTraining", b =>
                {
                    b.Property<Guid>("ExercisesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TrainingsId")
                        .HasColumnType("uuid");

                    b.HasKey("ExercisesId", "TrainingsId");

                    b.HasIndex("TrainingsId");

                    b.ToTable("ExerciseTraining");
                });

            modelBuilder.Entity("FitDash.Workout.Entities.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UrlVideo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("FitDash.Workout.Entities.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("Difficulty")
                        .HasColumnType("integer");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("FitDash.Workout.Entities.WorkoutRotine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("InactiveOnExpiration")
                        .HasColumnType("boolean");

                    b.Property<string>("Observations")
                        .HasColumnType("text");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Validate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("WorkoutRotines");
                });

            modelBuilder.Entity("TrainingWorkoutRotine", b =>
                {
                    b.Property<Guid>("TrainingsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkoutRotinesId")
                        .HasColumnType("uuid");

                    b.HasKey("TrainingsId", "WorkoutRotinesId");

                    b.HasIndex("WorkoutRotinesId");

                    b.ToTable("TrainingWorkoutRotine");
                });

            modelBuilder.Entity("ExerciseTraining", b =>
                {
                    b.HasOne("FitDash.Workout.Entities.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitDash.Workout.Entities.Training", null)
                        .WithMany()
                        .HasForeignKey("TrainingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrainingWorkoutRotine", b =>
                {
                    b.HasOne("FitDash.Workout.Entities.Training", null)
                        .WithMany()
                        .HasForeignKey("TrainingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitDash.Workout.Entities.WorkoutRotine", null)
                        .WithMany()
                        .HasForeignKey("WorkoutRotinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
