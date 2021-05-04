using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkAPI.Migrations
{
    public partial class AddedSpacePortsDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_SpacePort_SpacePortId",
                table: "Parkings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpacePort",
                table: "SpacePort");

            migrationBuilder.RenameTable(
                name: "SpacePort",
                newName: "SpacePorts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpacePorts",
                table: "SpacePorts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_SpacePorts_SpacePortId",
                table: "Parkings",
                column: "SpacePortId",
                principalTable: "SpacePorts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_SpacePorts_SpacePortId",
                table: "Parkings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpacePorts",
                table: "SpacePorts");

            migrationBuilder.RenameTable(
                name: "SpacePorts",
                newName: "SpacePort");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpacePort",
                table: "SpacePort",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_SpacePort_SpacePortId",
                table: "Parkings",
                column: "SpacePortId",
                principalTable: "SpacePort",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
