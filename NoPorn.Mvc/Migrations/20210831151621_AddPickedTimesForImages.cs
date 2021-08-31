using Microsoft.EntityFrameworkCore.Migrations;

namespace NoPorn.Mvc.Migrations
{
    public partial class AddPickedTimesForImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PickedTimes",
                table: "Images",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickedTimes",
                table: "Images");
        }
    }
}
