using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeBooth.Data.Migrations
{
    public partial class AddRelationsToReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Reservations",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StudioId",
                table: "Reservations",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StudioServiceId",
                table: "Reservations",
                column: "StudioServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_ClientId",
                table: "Reservations",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Studios_StudioId",
                table: "Reservations",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_StudioServices_StudioServiceId",
                table: "Reservations",
                column: "StudioServiceId",
                principalTable: "StudioServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ClientId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Studios_StudioId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_StudioServices_StudioServiceId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_StudioId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_StudioServiceId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Reservations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
