using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class update_room_and_guest_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "rooms",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "rooms",
                newName: "level");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "rooms",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "InMaintenace",
                table: "rooms",
                newName: "in_maintenace");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "guests",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "guests",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "guests",
                newName: "last_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "rooms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "level",
                table: "rooms",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "rooms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "in_maintenace",
                table: "rooms",
                newName: "InMaintenace");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "guests",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "guests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "guests",
                newName: "LastName");
        }
    }
}
