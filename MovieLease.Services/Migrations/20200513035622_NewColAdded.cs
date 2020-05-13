using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieLease.Services.Migrations
{
    public partial class NewColAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Records",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Records");
        }
    }
}
