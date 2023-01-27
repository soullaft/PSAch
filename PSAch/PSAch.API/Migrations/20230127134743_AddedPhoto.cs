using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSAch.API.Migrations
{
    public partial class AddedPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievement_Games_GameId",
                table: "Achievement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achievement",
                table: "Achievement");

            migrationBuilder.RenameTable(
                name: "Achievement",
                newName: "Achievements");

            migrationBuilder.RenameIndex(
                name: "IX_Achievement_GameId",
                table: "Achievements",
                newName: "IX_Achievements_GameId");

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Games",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Achievements",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Achievements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achievements",
                table: "Achievements",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bytes = table.Column<byte[]>(type: "BLOB", nullable: false),
                    FileExtensions = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_PhotoId",
                table: "Games",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_PhotoId",
                table: "Achievements",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Games_GameId",
                table: "Achievements",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Photos_PhotoId",
                table: "Achievements",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Photos_PhotoId",
                table: "Games",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Games_GameId",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Photos_PhotoId",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Photos_PhotoId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Games_PhotoId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achievements",
                table: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_PhotoId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Achievements");

            migrationBuilder.RenameTable(
                name: "Achievements",
                newName: "Achievement");

            migrationBuilder.RenameIndex(
                name: "IX_Achievements_GameId",
                table: "Achievement",
                newName: "IX_Achievement_GameId");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Achievement",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achievement",
                table: "Achievement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievement_Games_GameId",
                table: "Achievement",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
