using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdam.Configuration.Service.Migrations
{
    public partial class addCustomerGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyCode = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CustomerGroupCode = table.Column<string>(type: "text", nullable: true),
                    CustomerGroupName = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyCode = table.Column<string>(type: "text", nullable: true),
                    ProductCode = table.Column<string>(type: "text", nullable: true),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    MarketName = table.Column<string>(type: "text", nullable: true),
                    Uom = table.Column<string>(type: "text", nullable: true),
                    MethodValuating = table.Column<string>(type: "text", nullable: true),
                    PricingMethod = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CompanyCode1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyCode1",
                        column: x => x.CompanyCode1,
                        principalTable: "Companies",
                        principalColumn: "CompanyCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGroupPricings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    PriceName = table.Column<string>(type: "text", nullable: true),
                    StartActive = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndActive = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroupPricings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerGroupPricings_CustomerGroups_CustomerGroupId",
                        column: x => x.CustomerGroupId,
                        principalTable: "CustomerGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerGroupPricings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGroupPricingDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerGroupPricingId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsFixedPrice = table.Column<bool>(type: "boolean", nullable: false),
                    MappingColumn = table.Column<string>(type: "text", nullable: true),
                    PriceName = table.Column<string>(type: "text", nullable: true),
                    StartUnit = table.Column<decimal>(type: "numeric", nullable: false),
                    EndUnit = table.Column<decimal>(type: "numeric", nullable: false),
                    SalesPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroupPricingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerGroupPricingDetails_CustomerGroupPricings_CustomerG~",
                        column: x => x.CustomerGroupPricingId,
                        principalTable: "CustomerGroupPricings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroupPricingDetails_CustomerGroupPricingId",
                table: "CustomerGroupPricingDetails",
                column: "CustomerGroupPricingId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroupPricings_CustomerGroupId",
                table: "CustomerGroupPricings",
                column: "CustomerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroupPricings_ProductId",
                table: "CustomerGroupPricings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroups_CustomerGroupCode_CompanyCode",
                table: "CustomerGroups",
                columns: new[] { "CustomerGroupCode", "CompanyCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyCode1",
                table: "Products",
                column: "CompanyCode1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCode_CompanyCode",
                table: "Products",
                columns: new[] { "ProductCode", "CompanyCode" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerGroupPricingDetails");

            migrationBuilder.DropTable(
                name: "CustomerGroupPricings");

            migrationBuilder.DropTable(
                name: "CustomerGroups");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
