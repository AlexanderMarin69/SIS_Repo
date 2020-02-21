using Microsoft.EntityFrameworkCore.Migrations;

namespace vueproject.Migrations
{
    public partial class filePathTooInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Invoices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Invoices");
        }
    }
}
