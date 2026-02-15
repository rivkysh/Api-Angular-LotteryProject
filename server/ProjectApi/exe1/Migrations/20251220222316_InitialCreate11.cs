using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exe1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Donors_Doner_id",
                table: "Prizes");

            migrationBuilder.RenameColumn(
                name: "Doner_id",
                table: "Prizes",
                newName: "DonorId");

            migrationBuilder.RenameIndex(
                name: "IX_Prizes_Doner_id",
                table: "Prizes",
                newName: "IX_Prizes_DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Donors_DonorId",
                table: "Prizes",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Donors_DonorId",
                table: "Prizes");

            migrationBuilder.RenameColumn(
                name: "DonorId",
                table: "Prizes",
                newName: "Doner_id");

            migrationBuilder.RenameIndex(
                name: "IX_Prizes_DonorId",
                table: "Prizes",
                newName: "IX_Prizes_Doner_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Donors_Doner_id",
                table: "Prizes",
                column: "Doner_id",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
