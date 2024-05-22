using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collibri.Migrations
{
    /// <inheritdoc />
    public partial class _03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomMembers_AspNetUsers_AccountId",
                table: "RoomMembers");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMembers_Account_AccountId",
                table: "RoomMembers",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomMembers_Account_AccountId",
                table: "RoomMembers");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMembers_AspNetUsers_AccountId",
                table: "RoomMembers",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
