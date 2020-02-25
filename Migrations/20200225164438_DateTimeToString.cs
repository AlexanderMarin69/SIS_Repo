using Microsoft.EntityFrameworkCore.Migrations;

namespace vueproject.Migrations
{
    public partial class DateTimeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateCreatedString",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryDateString",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceDateString",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoicePayDateString",
                table: "Invoices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreatedString",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "DeliveryDateString",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceDateString",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoicePayDateString",
                table: "Invoices");
        }
    }
}
