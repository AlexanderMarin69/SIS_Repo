using Microsoft.EntityFrameworkCore.Migrations;

namespace vueproject.Migrations
{
    public partial class descriptiveDataForSelectList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descriptiveDataForSelectList",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descriptiveDataForSelectList",
                table: "Customers");
        }
    }
}
