using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeBooth.Data.Migrations
{
    public partial class ReplaceStudioOwnerWithHost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studios_AspNetUsers_OwnerId",
                table: "Studios");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Studios",
                newName: "HostId");

            migrationBuilder.RenameIndex(
                name: "IX_Studios_OwnerId",
                table: "Studios",
                newName: "IX_Studios_HostId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Studios_AspNetUsers_HostId",
                table: "Studios",
                column: "HostId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studios_AspNetUsers_HostId",
                table: "Studios");

            migrationBuilder.RenameColumn(
                name: "HostId",
                table: "Studios",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Studios_HostId",
                table: "Studios",
                newName: "IX_Studios_OwnerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddForeignKey(
                name: "FK_Studios_AspNetUsers_OwnerId",
                table: "Studios",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
