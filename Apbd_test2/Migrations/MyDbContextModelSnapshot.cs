﻿// <auto-generated />
using System;
using Apbd_test2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Apbd_test2.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Apbd_test2.Model.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RaceId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RaceId");

                    b.ToTable("Races");

                    b.HasData(
                        new
                        {
                            RaceId = 1,
                            Date = new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Local),
                            Location = "Monaco",
                            Name = "MonacoGP"
                        });
                });

            modelBuilder.Entity("Apbd_test2.Model.RaceParticipation", b =>
                {
                    b.Property<int>("TrackRaceId")
                        .HasColumnType("int");

                    b.Property<int>("RacerId")
                        .HasColumnType("int");

                    b.Property<int>("FinishTimeInSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("TrackRaceId", "RacerId");

                    b.HasIndex("RacerId");

                    b.ToTable("RaceParticipations");

                    b.HasData(
                        new
                        {
                            TrackRaceId = 1,
                            RacerId = 1,
                            FinishTimeInSeconds = 400,
                            Position = 1
                        });
                });

            modelBuilder.Entity("Apbd_test2.Model.Racer", b =>
                {
                    b.Property<int>("RacerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RacerId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RacerId");

                    b.ToTable("Racers");

                    b.HasData(
                        new
                        {
                            RacerId = 1,
                            FirstName = "Michael",
                            LastName = "Schumaher"
                        });
                });

            modelBuilder.Entity("Apbd_test2.Model.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackId"));

                    b.Property<decimal>("LengthKm")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TrackId");

                    b.ToTable("Tracks");

                    b.HasData(
                        new
                        {
                            TrackId = 1,
                            LengthKm = 4.5m,
                            Name = "Monaco GP"
                        });
                });

            modelBuilder.Entity("Apbd_test2.Model.TrackRace", b =>
                {
                    b.Property<int>("TrackRaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackRaceId"));

                    b.Property<int?>("BestTimeInSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Laps")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("TrackRaceId");

                    b.HasIndex("RaceId");

                    b.HasIndex("TrackId");

                    b.ToTable("TrackRaces");

                    b.HasData(
                        new
                        {
                            TrackRaceId = 1,
                            BestTimeInSeconds = 69,
                            Laps = 78,
                            RaceId = 1,
                            TrackId = 1
                        });
                });

            modelBuilder.Entity("Apbd_test2.Model.RaceParticipation", b =>
                {
                    b.HasOne("Apbd_test2.Model.Racer", "Racer")
                        .WithMany("RaceParticipations")
                        .HasForeignKey("RacerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apbd_test2.Model.TrackRace", "TrackRace")
                        .WithMany()
                        .HasForeignKey("TrackRaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Racer");

                    b.Navigation("TrackRace");
                });

            modelBuilder.Entity("Apbd_test2.Model.TrackRace", b =>
                {
                    b.HasOne("Apbd_test2.Model.Race", "Race")
                        .WithMany("TrackRaces")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Apbd_test2.Model.Track", "Track")
                        .WithMany("TrackRaces")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Apbd_test2.Model.Race", b =>
                {
                    b.Navigation("TrackRaces");
                });

            modelBuilder.Entity("Apbd_test2.Model.Racer", b =>
                {
                    b.Navigation("RaceParticipations");
                });

            modelBuilder.Entity("Apbd_test2.Model.Track", b =>
                {
                    b.Navigation("TrackRaces");
                });
#pragma warning restore 612, 618
        }
    }
}
