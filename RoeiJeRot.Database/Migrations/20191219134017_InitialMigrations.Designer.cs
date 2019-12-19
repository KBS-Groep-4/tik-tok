﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoeiJeRot.Database.Database;

namespace RoeiJeRot.Database.Migrations
{
    [DbContext(typeof(RoeiJeRotDbContext))]
    [Migration("20191219134017_InitialMigrations")]
    partial class InitialMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RoeiJeRot.Database.Database.BoatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HasCommanderSeat")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PossiblePassengers")
                        .HasColumnType("int");

                    b.Property<int>("RequiredLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("boat_types");
                });

            modelBuilder.Entity("RoeiJeRot.Database.Database.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("permissions");
                });

            modelBuilder.Entity("RoeiJeRot.Database.Database.SailingBoat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoatTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoatTypeId");

                    b.ToTable("sailing_boats");
                });

            modelBuilder.Entity("RoeiJeRot.Database.Database.SailingBoatDamageReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DamageFixedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DamagedAtDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DamagedById")
                        .HasColumnType("int");

                    b.Property<int>("DamagedSailingBoatId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DamagedById");

                    b.HasIndex("DamagedSailingBoatId");

                    b.ToTable("sailing_boat_damage_reports");
                });

            modelBuilder.Entity("RoeiJeRot.Database.Database.SailingCompetition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("sailing_competitions");
                });

            modelBuilder.Entity("RoeiJeRot.Database.Database.SailingCompetitionParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("SailingCompetitionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("SailingCompetitionId");

                    b.ToTable("sailing_competition_participants");
                });

            modelBuilder.Entity("RoeiJeRot.Database.Database.SailingReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("ReservedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("ReservedSailingBoatId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservedByUserId");

                    b.HasIndex("ReservedSailingBoatId");

                    b.ToTable("sailing_reservations");
                });

            modelBuilder.Entity("RoeiJeRot.Database.Database.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SailingLevel")
                        .HasColumnType("int");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("RoeiJeRot.Database.Database.UserPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("UserId");

                    b.ToTable("user_permissions");
                });

            modelBuilder.Entity("RoeiJeRot.Database.Database.SailingBoat", b =>
                {
                    b.HasOne("RoeiJeRot.Database.Database.BoatType", "BoatType")
                        .WithMany()
                        .HasForeignKey("BoatTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoeiJeRot.Database.Database.SailingBoatDamageReport", b =>
                {
                    b.HasOne("RoeiJeRot.Database.Database.User", "DamagedBy")
                        .WithMany("DamageReports")
                        .HasForeignKey("DamagedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoeiJeRot.Database.Database.SailingBoat", "DamagedSailingBoat")
                        .WithMany("DamageReports")
                        .HasForeignKey("DamagedSailingBoatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoeiJeRot.Database.Database.SailingCompetition", b =>
                {
                    b.HasOne("RoeiJeRot.Database.Database.SailingReservation", "SailingReservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoeiJeRot.Database.Database.SailingCompetitionParticipant", b =>
                {
                    b.HasOne("RoeiJeRot.Database.Database.User", "SailingParticipant")
                        .WithMany("SailingCompetitionParticipants")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoeiJeRot.Database.Database.SailingCompetition", "SailingCompetition")
                        .WithMany("SailingCompetitionParticipants")
                        .HasForeignKey("SailingCompetitionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoeiJeRot.Database.Database.SailingReservation", b =>
                {
                    b.HasOne("RoeiJeRot.Database.Database.User", "ReservedBy")
                        .WithMany("Reservations")
                        .HasForeignKey("ReservedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoeiJeRot.Database.Database.SailingBoat", "ReservedSailingBoat")
                        .WithMany("SailingReservations")
                        .HasForeignKey("ReservedSailingBoatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoeiJeRot.Database.Database.UserPermission", b =>
                {
                    b.HasOne("RoeiJeRot.Database.Database.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoeiJeRot.Database.Database.User", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
