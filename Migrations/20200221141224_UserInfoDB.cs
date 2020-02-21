using Microsoft.EntityFrameworkCore.Migrations;

namespace vueproject.Migrations
{
    public partial class UserInfoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserBankGiro",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserFax",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserMomsRegNr",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserOrgNr",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPhoneNumber",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPlusGiro",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankGiro",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MomsRegNr",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrgNr",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlusGiro",
                table: "ApplicationUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserBankGiro",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UserFax",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UserMomsRegNr",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UserOrgNr",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UserPhoneNumber",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UserPlusGiro",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "BankGiro",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "MomsRegNr",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "OrgNr",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "PlusGiro",
                table: "ApplicationUsers");
        }
    }
}
