﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Database.Tables.DoctorSpecialization", b =>
                {
                    b.Property<int>("FK_ID_User")
                        .HasColumnType("integer");

                    b.Property<string>("specialization")
                        .HasColumnType("text");

                    b.HasKey("FK_ID_User");

                    b.ToTable("DoctorSpecializations");
                });

            modelBuilder.Entity("Database.Tables.Request", b =>
                {
                    b.Property<int>("ID_request")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("FK_ID_doctor")
                        .HasColumnType("integer");

                    b.Property<int>("FK_ID_patient")
                        .HasColumnType("integer");

                    b.Property<DateTime>("datetime_appointment")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("datetime_created")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID_request");

                    b.HasIndex("FK_ID_doctor");

                    b.HasIndex("FK_ID_patient");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Database.Tables.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("account_type")
                        .HasColumnType("integer");

                    b.Property<string>("first_name")
                        .HasColumnType("text");

                    b.Property<DateTime>("last_logged")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("last_name")
                        .HasColumnType("text");

                    b.Property<string>("password_hash")
                        .HasColumnType("text");

                    b.Property<string>("user_name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Database.Tables.DoctorSpecialization", b =>
                {
                    b.HasOne("Database.Tables.User", "User")
                        .WithOne("Specialization")
                        .HasForeignKey("Database.Tables.DoctorSpecialization", "FK_ID_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Tables.Request", b =>
                {
                    b.HasOne("Database.Tables.User", "Doctor")
                        .WithMany()
                        .HasForeignKey("FK_ID_doctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Tables.User", "Patient")
                        .WithMany()
                        .HasForeignKey("FK_ID_patient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
