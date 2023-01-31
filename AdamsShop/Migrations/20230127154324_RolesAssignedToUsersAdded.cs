using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdamsShop.Migrations
{
    public partial class RolesAssignedToUsersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MyRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleAssignedToUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyRoleId = table.Column<int>(type: "int", nullable: false),
                    MyUserUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAssignedToUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleAssignedToUsers_MyRoles_MyRoleId",
                        column: x => x.MyRoleId,
                        principalTable: "MyRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAssignedToUsers_MyUsers_MyUserUserId",
                        column: x => x.MyUserUserId,
                        principalTable: "MyUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleAssignedToUsers_MyRoleId",
                table: "RoleAssignedToUsers",
                column: "MyRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAssignedToUsers_MyUserUserId",
                table: "RoleAssignedToUsers",
                column: "MyUserUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleAssignedToUsers");

            migrationBuilder.DropTable(
                name: "MyRoles");

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
    }
}
