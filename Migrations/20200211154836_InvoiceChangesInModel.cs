using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vueproject.Migrations
{
    public partial class InvoiceChangesInModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Invoices",
                newName: "UserZipCode");

            migrationBuilder.RenameColumn(
                name: "MessageText",
                table: "Invoices",
                newName: "UserInvoiceAddress");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Invoices",
                newName: "InvoicePayDate");

            migrationBuilder.AddColumn<string>(
                name: "CustomerCity",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerCountry",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerInvoiceAddress",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerZipCode",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceDate",
                table: "Invoices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InvoiceMessageText",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoicecPastDuePercentageFee",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCity",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCountry",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Invoices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_UserId",
                table: "Invoices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_CustomerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_UserId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerCity",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerCountry",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerInvoiceAddress",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerZipCode",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceMessageText",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoicecPastDuePercentageFee",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UserCity",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UserCountry",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "UserZipCode",
                table: "Invoices",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "UserInvoiceAddress",
                table: "Invoices",
                newName: "MessageText");

            migrationBuilder.RenameColumn(
                name: "InvoicePayDate",
                table: "Invoices",
                newName: "DateCreated");
        }
    }
}
