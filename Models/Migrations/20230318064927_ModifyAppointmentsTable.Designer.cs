﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnTime.Models;

#nullable disable

namespace OnTime.Models.Migrations
{
    [DbContext(typeof(OnTimeAppointmentsDbContext))]
    [Migration("20230318064927_ModifyAppointmentsTable")]
    partial class ModifyAppointmentsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OnTime.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AddedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdditionalInfo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasDefaultValue("-");

                    b.Property<DateTime>("AppointmentDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClassificationId")
                        .HasColumnType("int");

                    b.Property<string>("Objective")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Reason")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasDefaultValue("-");

                    b.HasKey("Id");

                    b.HasIndex("ClassificationId");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("OnTime.Models.Classification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Classifications", (string)null);
                });

            modelBuilder.Entity("OnTime.Models.Appointment", b =>
                {
                    b.HasOne("OnTime.Models.Classification", "Classification")
                        .WithMany()
                        .HasForeignKey("ClassificationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Classification");
                });
#pragma warning restore 612, 618
        }
    }
}
