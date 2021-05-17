using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeBooth.Data.Migrations
{
    public partial class AddRelationsToStudioService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudioServices_Studios_StudioId",
                table: "StudioServices");

            migrationBuilder.AlterColumn<int>(
                name: "StudioId",
                table: "StudioServices",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudioServices_Studios_StudioId",
                table: "StudioServices",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudioServices_Studios_StudioId",
                table: "StudioServices");

            migrationBuilder.AlterColumn<int>(
                name: "StudioId",
                table: "StudioServices",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_StudioServices_Studios_StudioId",
                table: "StudioServices",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
