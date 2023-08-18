using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcelProject.Migrations
{
    public partial class vvv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "ADMIN_USER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "ADMIN_USER",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
