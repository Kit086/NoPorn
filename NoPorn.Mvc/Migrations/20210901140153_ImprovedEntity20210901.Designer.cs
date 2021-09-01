﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoPorn.Mvc.Models;

namespace NoPorn.Mvc.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210901140153_ImprovedEntity20210901")]
    partial class ImprovedEntity20210901
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-preview.7.21378.4");

            modelBuilder.Entity("NoPorn.Mvc.Models.Girl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameCN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NamePY")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Girls");
                });

            modelBuilder.Entity("NoPorn.Mvc.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("GirlId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("PickedTimes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GirlId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("NoPorn.Mvc.Models.Image", b =>
                {
                    b.HasOne("NoPorn.Mvc.Models.Girl", "Girl")
                        .WithMany("Images")
                        .HasForeignKey("GirlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Girl");
                });

            modelBuilder.Entity("NoPorn.Mvc.Models.Girl", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
