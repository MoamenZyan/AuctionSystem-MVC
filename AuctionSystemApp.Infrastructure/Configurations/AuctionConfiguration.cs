using AuctionSystemApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Infrastructure.Configurations
{
    public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.ToTable("Auctions");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(256)
                    .IsRequired();

            builder.Property(x => x.Description)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(2064)
                    .IsRequired();

            builder.Property(x => x.PhotoPath)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(256)
                    .IsRequired();

            builder.OwnsOne(x => x.AuctionTime, at =>
            {
                at.Property(tw => tw.From)
                    .HasColumnType("DATETIME2")
                    .IsRequired();

                at.Property(tw => tw.To)
                    .HasColumnType("DATETIME2")
                    .IsRequired();

            });

            // Relations
            builder.HasOne(x => x.User)
                .WithMany(x => x.OwnedAuctions)
                .HasForeignKey(x => x.UserId);
        }
    }
}
