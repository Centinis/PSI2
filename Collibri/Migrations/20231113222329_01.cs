using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collibri.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomMember_AspNetUsers_AccountId",
                table: "RoomMember");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomMember_Rooms_RoomId",
                table: "RoomMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomMember",
                table: "RoomMember");

            migrationBuilder.RenameTable(
                name: "RoomMember",
                newName: "RoomMembers");

            migrationBuilder.RenameIndex(
                name: "IX_RoomMember_AccountId",
                table: "RoomMembers",
                newName: "IX_RoomMembers_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomMembers",
                table: "RoomMembers",
                columns: new[] { "RoomId", "AccountId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMembers_AspNetUsers_AccountId",
                table: "RoomMembers",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMembers_Rooms_RoomId",
                table: "RoomMembers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomMembers_AspNetUsers_AccountId",
                table: "RoomMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomMembers_Rooms_RoomId",
                table: "RoomMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomMembers",
                table: "RoomMembers");

            migrationBuilder.RenameTable(
                name: "RoomMembers",
                newName: "RoomMember");

            migrationBuilder.RenameIndex(
                name: "IX_RoomMembers_AccountId",
                table: "RoomMember",
                newName: "IX_RoomMember_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomMember",
                table: "RoomMember",
                columns: new[] { "RoomId", "AccountId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMember_AspNetUsers_AccountId",
                table: "RoomMember",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMember_Rooms_RoomId",
                table: "RoomMember",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
