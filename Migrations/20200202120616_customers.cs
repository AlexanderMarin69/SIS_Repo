using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vueproject.Migrations
{
    public partial class customers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<decimal>(nullable: false),
                    InvoiceAddress = table.Column<string>(nullable: true),
                    SecondInvoiceAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<decimal>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    OrganisationNumber = table.Column<decimal>(nullable: false),
                    PhoneNumber = table.Column<decimal>(nullable: false),
                    SecondPhoneNumber = table.Column<decimal>(nullable: false),
                    Fax = table.Column<decimal>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    WebAddress = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
