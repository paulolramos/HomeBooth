using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeBooth.Data.Migrations
{
    public partial class UpdateStudioFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studios_StudioAddresses_AddressId",
                table: "Studios");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Studios",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Studios_StudioAddresses_AddressId",
                table: "Studios",
                column: "AddressId",
                principalTable: "StudioAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studios_StudioAddresses_AddressId",
                table: "Studios");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Studios",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Studios_StudioAddresses_AddressId",
                table: "Studios",
                column: "AddressId",
                principalTable: "StudioAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
