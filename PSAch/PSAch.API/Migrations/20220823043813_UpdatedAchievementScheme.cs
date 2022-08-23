using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSAch.API.Migrations
{
    public partial class UpdatedAchievementScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievement_Games_GameId",
                table: "Achievement");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Achievement",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Achievement_Games_GameId",
                table: "Achievement",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievement_Games_GameId",
                table: "Achievement");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Achievement",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievement_Games_GameId",
                table: "Achievement",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
