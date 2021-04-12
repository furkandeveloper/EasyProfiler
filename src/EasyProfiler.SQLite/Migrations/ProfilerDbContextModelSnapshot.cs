﻿// <auto-generated />
using System;
using EasyProfiler.SQLite.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyProfiler.SQLite.Migrations
{
    [DbContext(typeof(ProfilerDbContext))]
    partial class ProfilerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12");

            modelBuilder.Entity("EasyProfiler.Core.Entities.Profiler", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<long>("Duration")
                        .HasColumnType("bigint");

                    b.Property<string>("Query")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("QueryType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Duration");

                    b.ToTable("Profilers");
                });
#pragma warning restore 612, 618
        }
    }
}
