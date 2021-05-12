using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeBooth.Data.Migrations
{
    public partial class modifyDateStamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudioOwner_CreatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudioOwner_UpdatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StudioOwner_CreatedOn",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StudioOwner_UpdatedOn",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true);
        }
    }
}
