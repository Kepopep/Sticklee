using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODO.Migrations
{
    /// <inheritdoc />
    public partial class RefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabitLogs_Habits_HabitId",
                table: "HabitLogs");

            migrationBuilder.DropIndex(
                name: "IX_HabitLogs_HabitId",
                table: "HabitLogs");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    ExpireDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.CreateIndex(
                name: "IX_HabitLogs_HabitId",
                table: "HabitLogs",
                column: "HabitId");

            migrationBuilder.AddForeignKey(
                name: "FK_HabitLogs_Habits_HabitId",
                table: "HabitLogs",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
