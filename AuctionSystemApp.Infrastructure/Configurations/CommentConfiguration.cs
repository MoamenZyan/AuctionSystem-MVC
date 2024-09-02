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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CommentContent)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(1024)
                    .IsRequired();

            builder.Property(x => x.CreatedAt)
                    .HasColumnType("DATETIME2")
                    .IsRequired();

            // Relations
            builder.HasOne(x => x.Auction)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.AuctionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
