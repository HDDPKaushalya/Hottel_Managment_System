﻿// <auto-generated />
using DemoApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoApp.Migrations
{
    [DbContext(typeof(ApplicationDbcontex))]
    [Migration("20241119044709_mssql.container_migration_526")]
    partial class mssqlcontainer_migration_526
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DemoApp.Model.RoomModel", b =>
                {
                    b.Property<string>("RoomID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RoomCapacity")
                        .HasColumnType("int");

                    b.Property<string>("RoomCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RoomPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RoomID");

                    b.ToTable("RoomModels");
                });
#pragma warning restore 612, 618
        }
    }
}
