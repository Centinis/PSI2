using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collibri.Migrations
{
    /// <inheritdoc />
    public partial class _06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomMembers",
                table: "RoomMembers");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "RoomMembers");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "RoomMembers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomMembers",
                table: "RoomMembers",
                columns: new[] { "RoomId", "Username" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomMembers",
                table: "RoomMembers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "RoomMembers");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "RoomMembers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomMembers",
                table: "RoomMembers",
                columns: new[] { "RoomId", "AccountId" });
        }
    }
}
