﻿// <auto-generated />
using System;
using CarMeetingManager.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarMeetingManager.Migrations
{
    [DbContext(typeof(CarMeetingContext))]
    [Migration("20181116133533_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarMeetingManager.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Displacement");

                    b.Property<int>("LoweringId");

                    b.Property<int>("MakeId");

                    b.Property<int>("MemberId");

                    b.Property<string>("Model");

                    b.Property<int>("ProductionYear");

                    b.Property<string>("Wheels");

                    b.HasKey("CarId");

                    b.HasIndex("LoweringId");

                    b.HasIndex("MakeId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarMeetingManager.Models.CarMake", b =>
                {
                    b.Property<int>("MakeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode");

                    b.Property<string>("Make");

                    b.HasKey("MakeId");

                    b.ToTable("CarMakes");
                });

            modelBuilder.Entity("CarMeetingManager.Models.Club", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contact")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.HasKey("ClubId");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("CarMeetingManager.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("EventTypeId");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("EventId");

                    b.HasIndex("EventTypeId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("CarMeetingManager.Models.EventType", b =>
                {
                    b.Property<int>("EventTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Type");

                    b.HasKey("EventTypeId");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("CarMeetingManager.Models.Lowering", b =>
                {
                    b.Property<int>("LoweringId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Type");

                    b.HasKey("LoweringId");

                    b.ToTable("Lowerings");
                });

            modelBuilder.Entity("CarMeetingManager.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId");

                    b.Property<int?>("CarId1");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<int>("ClubId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordSalt");

                    b.Property<string>("PostalCode")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("MemberId");

                    b.HasIndex("CarId1");

                    b.HasIndex("ClubId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("CarMeetingManager.Models.Registration", b =>
                {
                    b.Property<int>("RegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId");

                    b.Property<int>("MemberId");

                    b.HasKey("RegistrationId");

                    b.HasIndex("EventId");

                    b.HasIndex("MemberId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("CarMeetingManager.Models.Car", b =>
                {
                    b.HasOne("CarMeetingManager.Models.Lowering", "Lowering")
                        .WithMany()
                        .HasForeignKey("LoweringId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarMeetingManager.Models.CarMake", "Make")
                        .WithMany()
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarMeetingManager.Models.Event", b =>
                {
                    b.HasOne("CarMeetingManager.Models.EventType", "Type")
                        .WithMany()
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarMeetingManager.Models.Member", b =>
                {
                    b.HasOne("CarMeetingManager.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId1");

                    b.HasOne("CarMeetingManager.Models.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarMeetingManager.Models.Registration", b =>
                {
                    b.HasOne("CarMeetingManager.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarMeetingManager.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
