using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class update_booking_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_guests_GuestId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_rooms_RoomId",
                table: "bookings");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "bookings",
                newName: "start");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "bookings",
                newName: "end");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "bookings",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "bookings",
                newName: "room_id");

            migrationBuilder.RenameColumn(
                name: "PlacedAt",
                table: "bookings",
                newName: "placed_at");

            migrationBuilder.RenameColumn(
                name: "GuestId",
                table: "bookings",
                newName: "guest_id");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_RoomId",
                table: "bookings",
                newName: "IX_bookings_room_id");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_GuestId",
                table: "bookings",
                newName: "IX_bookings_guest_id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_guests_guest_id",
                table: "bookings",
                column: "guest_id",
                principalTable: "guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_rooms_room_id",
                table: "bookings",
                column: "room_id",
                principalTable: "rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_guests_guest_id",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_rooms_room_id",
                table: "bookings");

            migrationBuilder.RenameColumn(
                name: "start",
                table: "bookings",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "end",
                table: "bookings",
                newName: "End");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "bookings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "room_id",
                table: "bookings",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "placed_at",
                table: "bookings",
                newName: "PlacedAt");

            migrationBuilder.RenameColumn(
                name: "guest_id",
                table: "bookings",
                newName: "GuestId");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_room_id",
                table: "bookings",
                newName: "IX_bookings_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_guest_id",
                table: "bookings",
                newName: "IX_bookings_GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_guests_GuestId",
                table: "bookings",
                column: "GuestId",
                principalTable: "guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_rooms_RoomId",
                table: "bookings",
                column: "RoomId",
                principalTable: "rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
