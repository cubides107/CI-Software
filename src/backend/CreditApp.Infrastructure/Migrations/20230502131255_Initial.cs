using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetTithes = table.Column<double>(type: "float", nullable: false),
                    Placement = table.Column<double>(type: "float", nullable: false),
                    RentsReceived = table.Column<double>(type: "float", nullable: false),
                    Pension = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Outflows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diet = table.Column<double>(type: "float", nullable: false),
                    Transport = table.Column<double>(type: "float", nullable: false),
                    Education = table.Column<double>(type: "float", nullable: false),
                    Renting = table.Column<double>(type: "float", nullable: false),
                    PublicServices = table.Column<double>(type: "float", nullable: false),
                    LoanInstallmentCorp = table.Column<double>(type: "float", nullable: false),
                    BankCreditCardFees = table.Column<double>(type: "float", nullable: false),
                    OtherFees = table.Column<double>(type: "float", nullable: false),
                    OtherObligations = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outflows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Names = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TypeUser = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LandLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastNames = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Congregation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    District = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EPS = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true),
                    DateInitCorp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateInitMin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Token = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    WifeNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WifeLastNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WifePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Childrens = table.Column<int>(type: "int", nullable: true),
                    Persons = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherIncomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Concept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    IncomeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherIncomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherIncomes_Incomes_IncomeId",
                        column: x => x.IncomeId,
                        principalTable: "Incomes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CreditApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TypeCreditEnum = table.Column<int>(type: "int", nullable: false),
                    RequestedValue = table.Column<decimal>(type: "money", nullable: false),
                    RequestTime = table.Column<int>(type: "int", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCreditCorp = table.Column<bool>(type: "bit", nullable: false),
                    Stade = table.Column<int>(type: "int", nullable: false),
                    Credits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutflowId = table.Column<int>(type: "int", nullable: true),
                    IncomeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditApplications_Incomes_IncomeId",
                        column: x => x.IncomeId,
                        principalTable: "Incomes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditApplications_Outflows_OutflowId",
                        column: x => x.OutflowId,
                        principalTable: "Outflows",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditApplications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeDocument = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditApplicationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_CreditApplications_CreditApplicationId",
                        column: x => x.CreditApplicationId,
                        principalTable: "CreditApplications",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Childrens", "Congregation", "DateInitCorp", "DateInitMin", "DateOfBirth", "DepartmentId", "District", "DocumentId", "EPS", "Email", "Height", "LandLine", "LastNames", "MunicipalityId", "Names", "Password", "Persons", "PhoneNumber", "Token", "TypeUser", "Weight", "WifeLastNames", "WifeNames", "WifePhone" },
                values: new object[] { 1, null, null, null, null, null, null, null, null, null, null, "Admin@gmail.com", null, null, "Admin", null, "Admin", "356a192b7913b04c54574d18c28d46e6395428ab", null, null, null, 0, null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_CreditApplications_IncomeId",
                table: "CreditApplications",
                column: "IncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApplications_OutflowId",
                table: "CreditApplications",
                column: "OutflowId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApplications_UserId",
                table: "CreditApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CreditApplicationId",
                table: "Documents",
                column: "CreditApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherIncomes_IncomeId",
                table: "OtherIncomes",
                column: "IncomeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "OtherIncomes");

            migrationBuilder.DropTable(
                name: "CreditApplications");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Outflows");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
