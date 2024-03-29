﻿// <auto-generated />
using System;
using FitDash.Diet.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FitDash.Diet.Data.Migrations
{
    [DbContext(typeof(ReadModelSqlContext))]
    [Migration("20221229131445_Init_Migrate")]
    partial class Init_Migrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FitDash.Diet.Domain.Entities.BasalMetabolism", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ActivityFactor")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.Property<int>("YearsOld")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BasalMetabolisms");
                });

            modelBuilder.Entity("FitDash.Diet.Domain.Entities.Macronutrient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BasalMetabolismId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Calories")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Carbs")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Fat")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Protein")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("BasalMetabolismId")
                        .IsUnique();

                    b.ToTable("Macronutrients");
                });

            modelBuilder.Entity("FitDash.Diet.Domain.Entities.Meal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BaseUnit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Carbs")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Fat")
                        .HasColumnType("numeric");

                    b.Property<int>("MealType")
                        .HasColumnType("integer");

                    b.Property<decimal>("Protein")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("FitDash.Diet.Domain.Entities.Macronutrient", b =>
                {
                    b.HasOne("FitDash.Diet.Domain.Entities.BasalMetabolism", "BasalMetabolism")
                        .WithOne("Macronutrient")
                        .HasForeignKey("FitDash.Diet.Domain.Entities.Macronutrient", "BasalMetabolismId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BasalMetabolism");
                });

            modelBuilder.Entity("FitDash.Diet.Domain.Entities.BasalMetabolism", b =>
                {
                    b.Navigation("Macronutrient")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
