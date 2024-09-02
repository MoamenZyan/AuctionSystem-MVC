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
    public class AuctionUserConfiguration : IEntityTypeConfiguration<AuctionUser>
    {
        public void Configure(EntityTypeBuilder<AuctionUser> builder)
        {
            builder.ToTable("AuctionUsers");
            builder.HasKey(x => new { x.UserId, x.AuctionId });

            builder.Property(x => x.CurrentBid)
                    .HasColumnType("DECIMAL")
                    .IsRequired();

            builder.Property(x => x.LastBid)
                    .HasColumnType("DATETIME2")
                    .IsRequired();

            // Relations
            builder.HasOne(x => x.User)
                .WithMany(x => x.JoinedAuctions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Auction)
                    .WithMany(x => x.JoinedUsers)
                    .HasForeignKey(x => x.AuctionId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
