﻿// <auto-generated />
using System;
using AuctionSystemApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuctionSystemApp.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240824161625_Tables")]
    partial class Tables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuctionSystemApp.Domain.Entities.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2064)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Auctions", (string)null);
                });

            modelBuilder.Entity("AuctionSystemApp.Domain.Entities.AuctionUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<decimal>("CurrentBid")
                        .HasColumnType("DECIMAL");

                    b.HasKey("UserId", "AuctionId");

                    b.HasIndex("AuctionId");

                    b.ToTable("AuctionUsers", (string)null);
                });

            modelBuilder.Entity("AuctionSystemApp.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasMaxLength(144)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasMaxLength(144)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("AuctionSystemApp.Domain.Entities.Auction", b =>
                {
                    b.HasOne("AuctionSystemApp.Domain.Entities.User", "User")
                        .WithMany("OwnedAuctions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("AuctionSystemApp.Domain.Entities.TimeWindow", "AuctionTime", b1 =>
                        {
                            b1.Property<int>("AuctionId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("From")
                                .HasColumnType("DATETIME2");

                            b1.Property<DateTime>("To")
                                .HasColumnType("DATETIME2");

                            b1.HasKey("AuctionId");

                            b1.ToTable("Auctions");

                            b1.WithOwner()
                                .HasForeignKey("AuctionId");
                        });

                    b.Navigation("AuctionTime")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuctionSystemApp.Domain.Entities.AuctionUser", b =>
                {
                    b.HasOne("AuctionSystemApp.Domain.Entities.Auction", "Auction")
                        .WithMany("JoinedUsers")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuctionSystemApp.Domain.Entities.User", "User")
                        .WithMany("JoinedAuctions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuctionSystemApp.Domain.Entities.Auction", b =>
                {
                    b.Navigation("JoinedUsers");
                });

            modelBuilder.Entity("AuctionSystemApp.Domain.Entities.User", b =>
                {
                    b.Navigation("JoinedAuctions");

                    b.Navigation("OwnedAuctions");
                });
#pragma warning restore 612, 618
        }
    }
}
