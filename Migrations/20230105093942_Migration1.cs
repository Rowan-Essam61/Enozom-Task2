using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enozomtask.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "CHolidays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CHolidays_CountryID",
                table: "CHolidays",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_CHolidays_DayId",
                table: "CHolidays",
                column: "DayId");

            migrationBuilder.AddForeignKey(
                name: "FK_CHolidays_Countries_CountryID",
                table: "CHolidays",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CHolidays_Days_DayId",
                table: "CHolidays",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CHolidays_Countries_CountryID",
                table: "CHolidays");

            migrationBuilder.DropForeignKey(
                name: "FK_CHolidays_Days_DayId",
                table: "CHolidays");

            migrationBuilder.DropIndex(
                name: "IX_CHolidays_CountryID",
                table: "CHolidays");

            migrationBuilder.DropIndex(
                name: "IX_CHolidays_DayId",
                table: "CHolidays");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "CHolidays");
        }
    }
}
