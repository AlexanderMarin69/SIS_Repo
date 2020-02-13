using Microsoft.EntityFrameworkCore.Migrations;

namespace vueproject.Migrations
{
    public partial class associations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ModifiedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ModifiedById",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ModifiedById",
                table: "Products",
                newName: "AssociatedUserId");

            migrationBuilder.AlterColumn<string>(
                name: "AssociatedUserId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssociatedUserId",
                table: "Products",
                newName: "ModifiedById");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModifiedById",
                table: "Products",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ModifiedById",
                table: "Products",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
