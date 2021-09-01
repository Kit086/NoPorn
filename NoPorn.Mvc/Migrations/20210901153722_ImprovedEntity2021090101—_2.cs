using Microsoft.EntityFrameworkCore.Migrations;

namespace NoPorn.Mvc.Migrations
{
    public partial class ImprovedEntity2021090101_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameCN",
                table: "Girls");

            migrationBuilder.RenameColumn(
                name: "NamePY",
                table: "Girls",
                newName: "AvatarUrl");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Girls",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Girls");

            migrationBuilder.RenameColumn(
                name: "AvatarUrl",
                table: "Girls",
                newName: "NamePY");

            migrationBuilder.AddColumn<string>(
                name: "NameCN",
                table: "Girls",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
