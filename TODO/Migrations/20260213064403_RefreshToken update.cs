using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODO.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokenupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "RefreshTokens");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "RefreshTokens",
                newName: "TokenHash");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "RefreshTokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireAt",
                table: "RefreshTokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RevokeAt",
                table: "RefreshTokens",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "ExpireAt",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "RevokeAt",
                table: "RefreshTokens");

            migrationBuilder.RenameColumn(
                name: "TokenHash",
                table: "RefreshTokens",
                newName: "Token");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpireDate",
                table: "RefreshTokens",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
