using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRepositoryTest.Database.Migrations
{
    public partial class AddEngiteToCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Engine",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Engine",
                table: "Cars");
        }
    }
}
