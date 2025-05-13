using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ims.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CPF = table.Column<string>(type: "char(14)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CNPJ = table.Column<string>(type: "char(18)", nullable: true),
                    CorporateName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    TradeName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    StateRegistration = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BillingTerm = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Interest = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    Fine = table.Column<decimal>(type: "decimal(10,4)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    PostalCode = table.Column<string>(type: "char(9)", nullable: false),
                    State = table.Column<string>(type: "char(2)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Phone = table.Column<string>(type: "char(14)", nullable: true),
                    Mobile = table.Column<string>(type: "char(16)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Address = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => new { x.CustomerId, x.Address });
                    table.ForeignKey(
                        name: "FK_Email_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
