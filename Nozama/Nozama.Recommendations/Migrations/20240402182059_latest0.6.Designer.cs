﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Nozama.Recommendations.Migrations
{
    [DbContext(typeof(RecommendationsDbContext))]
    [Migration("20240402182059_latest0.6")]
    partial class latest06
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nozama.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Nozama.Model.Recommendation", b =>
                {
                    b.Property<int>("RecommendationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecommendationId"));

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("RecommendationId");

                    b.ToTable("Recommendations");
                });

            modelBuilder.Entity("Nozama.Model.Search", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Term")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Searches");
                });

            modelBuilder.Entity("Nozama.Model.StatsEntry", b =>
                {
                    b.Property<int>("StatsEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatsEntryId"));

                    b.Property<string>("Term")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("StatsEntryId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("ProductRecommendation", b =>
                {
                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.Property<int>("RecommendationsRecommendationId")
                        .HasColumnType("int");

                    b.HasKey("ProductsProductId", "RecommendationsRecommendationId");

                    b.HasIndex("RecommendationsRecommendationId");

                    b.ToTable("ProductRecommendation");
                });

            modelBuilder.Entity("ProductStatsEntry", b =>
                {
                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.Property<int>("StatsEntriesStatsEntryId")
                        .HasColumnType("int");

                    b.HasKey("ProductsProductId", "StatsEntriesStatsEntryId");

                    b.HasIndex("StatsEntriesStatsEntryId");

                    b.ToTable("ProductStatsEntry");
                });

            modelBuilder.Entity("ProductRecommendation", b =>
                {
                    b.HasOne("Nozama.Model.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nozama.Model.Recommendation", null)
                        .WithMany()
                        .HasForeignKey("RecommendationsRecommendationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductStatsEntry", b =>
                {
                    b.HasOne("Nozama.Model.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nozama.Model.StatsEntry", null)
                        .WithMany()
                        .HasForeignKey("StatsEntriesStatsEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
