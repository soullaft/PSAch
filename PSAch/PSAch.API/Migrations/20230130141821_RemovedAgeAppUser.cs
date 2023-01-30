using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSAch.API.Migrations
{
    public partial class RemovedAgeAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AppUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AppUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
