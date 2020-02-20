using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vueproject.Migrations
{
    public partial class chagnessssdfsdfsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ApplicationUsers",
                newName: "PaymentTerms");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Invoices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InvoicecPastDuePercentageFee",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerms",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverCustomerId",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverReferenceName",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerReference",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoicecPastDuePercentageFee",
                table: "ApplicationUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoicecPastDuePercentageFee",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PaymentTerms",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ReceiverCustomerId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ReceiverReferenceName",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerReference",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "InvoicecPastDuePercentageFee",
                table: "ApplicationUsers");

            migrationBuilder.RenameColumn(
                name: "PaymentTerms",
                table: "ApplicationUsers",
                newName: "Name");
        }
    }
}
