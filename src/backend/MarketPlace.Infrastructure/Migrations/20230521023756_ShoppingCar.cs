using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCarId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCars", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingCarId",
                table: "Products",
                column: "ShoppingCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingCars_ShoppingCarId",
                table: "Products",
                column: "ShoppingCarId",
                principalTable: "ShoppingCars",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingCars_ShoppingCarId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCars");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingCarId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShoppingCarId",
                table: "Products");
        }
    }
}
