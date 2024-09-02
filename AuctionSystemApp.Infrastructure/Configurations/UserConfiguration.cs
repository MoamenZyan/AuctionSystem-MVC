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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Fname)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(144)
                    .IsRequired();


            builder.Property(x => x.Lname)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(144)
                    .IsRequired();


            builder.Property(x => x.Email)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(255)
                    .IsRequired();

            builder.Property(x => x.Phone)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(15)
                    .IsRequired();

            builder.Property(x => x.PhotoPath)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(256)
                    .IsRequired();
        }
    }
}
