using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkAPI.Migrations
{
    public partial class ChangedParksToPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parks",
                table: "Parks");

            migrationBuilder.RenameTable(
                name: "Parks",
                newName: "Payments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Parks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parks",
                table: "Parks",
                column: "Id");
        }
    }
}
