using Microsoft.EntityFrameworkCore.Migrations;

namespace BookManagementApi.Migrations
{
    public partial class UpdateBookManagementApiMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "BookItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "BookItems");
        }
    }
}
