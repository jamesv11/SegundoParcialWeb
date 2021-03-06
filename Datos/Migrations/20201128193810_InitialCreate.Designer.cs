﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(TercerosContext))]
    [Migration("20201128193810_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidad.ImagenTercero", b =>
                {
                    b.Property<int>("ImagenTerceroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Imagen")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ImagenTerceroID");

                    b.ToTable("ImagenTercero");
                });

            modelBuilder.Entity("Entidad.Pago", b =>
                {
                    b.Property<int>("PagoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("IVA")
                        .HasColumnType("decimal(12,2)");

                    b.Property<string>("TerceroIdentificacion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TipoPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("PagoID");

                    b.HasIndex("TerceroIdentificacion");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("Entidad.Tercero", b =>
                {
                    b.Property<string>("TerceroIdentificacion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreFoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreTercero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SumaTotalPagos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TerceroID")
                        .HasColumnType("int");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TerceroIdentificacion");

                    b.ToTable("Terceros");
                });

            modelBuilder.Entity("Entidad.Pago", b =>
                {
                    b.HasOne("Entidad.Tercero", "Tercero")
                        .WithMany("ListaPagos")
                        .HasForeignKey("TerceroIdentificacion");
                });
#pragma warning restore 612, 618
        }
    }
}
