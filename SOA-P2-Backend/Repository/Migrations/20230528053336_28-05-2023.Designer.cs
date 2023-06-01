﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Context;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230528053336_28-05-2023")]
    partial class _28052023
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Activo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Activos");
                });

            modelBuilder.Entity("Domain.Entities.Activo_Empleado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("assignment_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("delivery_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_activo")
                        .HasColumnType("int");

                    b.Property<int>("id_empleoyee")
                        .HasColumnType("int");

                    b.Property<DateTime>("release_date")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("id_activo");

                    b.HasIndex("id_empleoyee");

                    b.ToTable("Activo_Empleado");
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("date_hire")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("id_people")
                        .IsRequired()
                        .HasColumnType("nvarchar(18)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("id_people");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Property<string>("curp")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<DateTime>("birth_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("curp");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Domain.Entities.Activo_Empleado", b =>
                {
                    b.HasOne("Domain.Entities.Activo", "Activo")
                        .WithMany("Activo_Empleado")
                        .HasForeignKey("id_activo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Empleado", "Empleado")
                        .WithMany("Activo_Empleado")
                        .HasForeignKey("id_empleoyee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activo");

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.HasOne("Domain.Entities.Persona", "Persona")
                        .WithMany("Empleado")
                        .HasForeignKey("id_people")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Domain.Entities.Activo", b =>
                {
                    b.Navigation("Activo_Empleado");
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.Navigation("Activo_Empleado");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Navigation("Empleado");
                });
#pragma warning restore 612, 618
        }
    }
}
