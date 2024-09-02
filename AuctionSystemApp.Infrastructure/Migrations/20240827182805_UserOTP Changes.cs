using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionSystemApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserOTPChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OTP",
                table: "UsersOTP",
                type: "VARCHAR(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OTP",
                table: "UsersOTP",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(7)",
                oldMaxLength: 7);
        }
    }
}
