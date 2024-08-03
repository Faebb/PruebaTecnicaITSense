﻿// <auto-generated />
using System;
using DataAcces.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAcces.EFCore.Migrations
{
    [DbContext(typeof(InventarioContext))]
    [Migration("20240803024028_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entidades.EstadoProducto", b =>
                {
                    b.Property<int>("EstadoProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoProductoId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoProductoId");

                    b.ToTable("EstadoProductos");
                });

            modelBuilder.Entity("Domain.Entidades.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"));

                    b.Property<int>("EstadoProductoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoElaboracion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}