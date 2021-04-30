using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkAPI.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropColumn(
                name: "ParkingStation",
                table: "Parks");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Parks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Parks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SpacePortId",
                table: "Parks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Parks");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Parks");

            migrationBuilder.DropColumn(
                name: "SpacePortId",
                table: "Parks");

            migrationBuilder.AddColumn<string>(
                name: "ParkingStation",
                table: "Parks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Invoice = table.Column<int>(type: "int", nullable: false),
                    ParkID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Parks_ParkID",
                        column: x => x.ParkID,
                        principalTable: "Parks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParkingId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StarTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ParkID",
                table: "Payments",
                column: "ParkID");
        }
    }
}
