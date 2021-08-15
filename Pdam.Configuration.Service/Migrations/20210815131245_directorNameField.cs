using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdam.Configuration.Service.Migrations
{
    public partial class directorNameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DirectorName",
                table: "Companies",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DirectorName",
                table: "Companies");
        }
    }
}
