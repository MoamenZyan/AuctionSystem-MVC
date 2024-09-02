using AuctionSystemApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionSystemApp.Infrastructure.Configurations
{
    public class UserOTPConfiguration : IEntityTypeConfiguration<UserOTP>
    {
        public void Configure(EntityTypeBuilder<UserOTP> builder)
        {
            builder.ToTable("UsersOTP");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OTP)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(7)
                    .IsRequired();

            builder.Property(x => x.Deadline)
                    .HasColumnType("DATETIME2")
                    .IsRequired();

            builder.Property(x => x.UserId)
                    .HasColumnType("INTEGER")
                    .IsRequired();
        }
    }
}
