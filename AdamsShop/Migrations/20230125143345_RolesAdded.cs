using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdamsShop.Migrations
{
    public partial class RolesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "MyUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuperUser",
                table: "MyUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUser",
                table: "MyUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "MyUsers");

            migrationBuilder.DropColumn(
                name: "IsSuperUser",
                table: "MyUsers");

            migrationBuilder.DropColumn(
                name: "IsUser",
                table: "MyUsers");
        }
    }
}
