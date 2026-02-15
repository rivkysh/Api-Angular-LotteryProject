using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exe1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Prizes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ThewinnerId",
                table: "Prizes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prizes_ThewinnerId",
                table: "Prizes",
                column: "ThewinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Users_ThewinnerId",
                table: "Prizes",
                column: "ThewinnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Users_ThewinnerId",
                table: "Prizes");

            migrationBuilder.DropIndex(
                name: "IX_Prizes_ThewinnerId",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "ThewinnerId",
                table: "Prizes");
        }
    }
}
