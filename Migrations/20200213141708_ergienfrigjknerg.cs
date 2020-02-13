using Microsoft.EntityFrameworkCore.Migrations;

namespace vueproject.Migrations
{
    public partial class ergienfrigjknerg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssociatedUser",
                table: "Customers",
                newName: "AssociatedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssociatedUserId",
                table: "Customers",
                newName: "AssociatedUser");
        }
    }
}
