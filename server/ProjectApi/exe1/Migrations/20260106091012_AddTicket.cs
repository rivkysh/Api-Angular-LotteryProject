using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exe1.Migrations
{
    /// <inheritdoc />
    public partial class AddTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketPrize");

            migrationBuilder.AddColumn<int>(
                name: "PrizeId",
                table: "Baskets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prizeId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_Prizes_prizeId",
                        column: x => x.prizeId,
                        principalTable: "Prizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_PrizeId",
                table: "Baskets",
                column: "PrizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_BasketId",
                table: "Ticket",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_prizeId",
                table: "Ticket",
                column: "prizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Prizes_PrizeId",
                table: "Baskets",
                column: "PrizeId",
                principalTable: "Prizes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Prizes_PrizeId",
                table: "Baskets");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_PrizeId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "PrizeId",
                table: "Baskets");

            migrationBuilder.CreateTable(
                name: "BasketPrize",
                columns: table => new
                {
                    OwnersId = table.Column<int>(type: "int", nullable: false),
                    YourCardsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketPrize", x => new { x.OwnersId, x.YourCardsId });
                    table.ForeignKey(
                        name: "FK_BasketPrize_Baskets_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketPrize_Prizes_YourCardsId",
                        column: x => x.YourCardsId,
                        principalTable: "Prizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketPrize_YourCardsId",
                table: "BasketPrize",
                column: "YourCardsId");
        }
    }
}
