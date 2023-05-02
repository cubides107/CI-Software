using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Debts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Debts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEntity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DebtBalance = table.Column<double>(type: "float", nullable: false),
                    QuotaValue = table.Column<double>(type: "float", nullable: false),
                    TimeRemainingPayment = table.Column<int>(type: "int", nullable: false),
                    CreditApplicationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debts_CreditApplications_CreditApplicationId",
                        column: x => x.CreditApplicationId,
                        principalTable: "CreditApplications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Debts_CreditApplicationId",
                table: "Debts",
                column: "CreditApplicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debts");
        }
    }
}
