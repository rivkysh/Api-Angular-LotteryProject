using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exe1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Users_User_id",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Donors_DonorId",
                table: "Prizes");

            migrationBuilder.DropIndex(
                name: "IX_Prizes_DonorId",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Prizes");

            migrationBuilder.RenameColumn(
                name: "User_id",
                table: "Baskets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Baskets_User_id",
                table: "Baskets",
                newName: "IX_Baskets_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Prizes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Prizes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Prizes_Doner_id",
                table: "Prizes",
                column: "Doner_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Donors_Doner_id",
                table: "Prizes",
                column: "Doner_id",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Donors_Doner_id",
                table: "Prizes");

            migrationBuilder.DropIndex(
                name: "IX_Prizes_Doner_id",
                table: "Prizes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Baskets",
                newName: "User_id");

            migrationBuilder.RenameIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                newName: "IX_Baskets_User_id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Prizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Prizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "Prizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prizes_DonorId",
                table: "Prizes",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Users_User_id",
                table: "Baskets",
                column: "User_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Donors_DonorId",
                table: "Prizes",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
