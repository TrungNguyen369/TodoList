﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodosBackEnd.Data;

#nullable disable

namespace TodosBackEnd.Migrations
{
    [DbContext(typeof(TodosDbContext))]
    [Migration("20221121114133_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TodosBackEnd.models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsComplete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Todos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsComplete = false,
                            Name = "Nhiệm vụ 1"
                        },
                        new
                        {
                            Id = 2,
                            IsComplete = false,
                            Name = "Nhiệm vụ 2"
                        },
                        new
                        {
                            Id = 3,
                            IsComplete = false,
                            Name = "Nhiệm vụ 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}