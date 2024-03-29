﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PRMSAPI.Models.Context;

namespace PRMSAPI.Migrations
{
    [DbContext(typeof(PRMSContext))]
    [Migration("20190721045205_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PRMSAPI.Models.Context.MPTT", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsLeaf")
                        .HasColumnType("bit");

                    b.Property<decimal>("LeftValue")
                        .HasColumnType("decimal");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OrderLevel")
                        .HasColumnType("int");

                    b.Property<decimal>("ParentId")
                        .HasColumnType("decimal");

                    b.Property<decimal>("RightValue")
                        .HasColumnType("decimal");

                    b.Property<decimal>("TreeId")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("Id");

                    b.ToTable("MPTT");
                });

            modelBuilder.Entity("PRMSAPI.Models.Context.ProjectTask", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,0)")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ProjectTask");
                });
#pragma warning restore 612, 618
        }
    }
}
