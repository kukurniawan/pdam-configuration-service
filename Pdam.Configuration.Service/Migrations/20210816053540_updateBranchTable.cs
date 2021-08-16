using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdam.Configuration.Service.Migrations
{
    public partial class updateBranchTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Branches_BranchName_CompanyCode",
                table: "Branches");

            migrationBuilder.AddColumn<string>(
                name: "BranchCode",
                table: "Branches",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchHeadName",
                table: "Branches",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Branches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_BranchCode_CompanyCode",
                table: "Branches",
                columns: new[] { "BranchCode", "CompanyCode" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Branches_BranchCode_CompanyCode",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "BranchCode",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "BranchHeadName",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Branches");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_BranchName_CompanyCode",
                table: "Branches",
                columns: new[] { "BranchName", "CompanyCode" },
                unique: true);
        }
    }
}
