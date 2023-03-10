// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication4.Database;

namespace WebApplication4.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20230117113435_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication4.Database.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tv",
                            Price = 850m,
                            dateTime = new DateTime(2023, 1, 14, 15, 34, 35, 634, DateTimeKind.Local).AddTicks(2743)
                        },
                        new
                        {
                            Id = 2,
                            Name = "Computer",
                            Price = 700m,
                            dateTime = new DateTime(2022, 11, 28, 15, 34, 35, 634, DateTimeKind.Local).AddTicks(8980)
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mobile-phone",
                            Price = 200m,
                            dateTime = new DateTime(2023, 1, 5, 15, 34, 35, 634, DateTimeKind.Local).AddTicks(8998)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
