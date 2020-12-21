using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HomeBooth.Data.Migrations
{
    public partial class DBModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studios_StudioRates_RateId",
                table: "Studios");

            migrationBuilder.DropForeignKey(
                name: "FK_Studios_StudioSchedules_ScheduleId",
                table: "Studios");

            migrationBuilder.DropTable(
                name: "StudioRates");

            migrationBuilder.DropIndex(
                name: "IX_Studios_RateId",
                table: "Studios");

            migrationBuilder.DropIndex(
                name: "IX_Studios_ScheduleId",
                table: "Studios");

            migrationBuilder.DropColumn(
                name: "RateId",
                table: "Studios");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Studios");

            migrationBuilder.AddColumn<float>(
                name: "AdditionalCost",
                table: "StudioServices",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StudioServices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "StudioServices",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "StudioSchedules",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StudioId",
                table: "StudioSchedules",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "StudioSchedules",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Studios",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Studios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Rate",
                table: "Studios",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StudioItems",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quanitity",
                table: "StudioItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ClientContact",
                table: "Reservations",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Reservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Reservations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Reservations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Reservations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "Reservations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Reservations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Reservations",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Reservations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "StudioContact",
                table: "Reservations",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudioId",
                table: "Reservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudioServiceId",
                table: "Reservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Reservations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_StudioSchedules_StudioId",
                table: "StudioSchedules",
                column: "StudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudioSchedules_Studios_StudioId",
                table: "StudioSchedules",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudioSchedules_Studios_StudioId",
                table: "StudioSchedules");

            migrationBuilder.DropIndex(
                name: "IX_StudioSchedules_StudioId",
                table: "StudioSchedules");

            migrationBuilder.DropColumn(
                name: "AdditionalCost",
                table: "StudioServices");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "StudioServices");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "StudioServices");

            migrationBuilder.DropColumn(
                name: "From",
                table: "StudioSchedules");

            migrationBuilder.DropColumn(
                name: "StudioId",
                table: "StudioSchedules");

            migrationBuilder.DropColumn(
                name: "To",
                table: "StudioSchedules");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Studios");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Studios");

            migrationBuilder.DropColumn(
                name: "Quanitity",
                table: "StudioItems");

            migrationBuilder.DropColumn(
                name: "ClientContact",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StudioContact",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StudioId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StudioServiceId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Studios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RateId",
                table: "Studios",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Studios",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StudioItems",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "StudioRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudioRates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studios_RateId",
                table: "Studios",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_Studios_ScheduleId",
                table: "Studios",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studios_StudioRates_RateId",
                table: "Studios",
                column: "RateId",
                principalTable: "StudioRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Studios_StudioSchedules_ScheduleId",
                table: "Studios",
                column: "ScheduleId",
                principalTable: "StudioSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
