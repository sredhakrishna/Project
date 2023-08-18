using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcelProject.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "ADMIN_USER",
                newName: "PhoneNo");

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "ADMIN_USER",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Last_Name",
                table: "ADMIN_USER",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "ADMIN_USER");

            migrationBuilder.DropColumn(
                name: "Last_Name",
                table: "ADMIN_USER");

            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "ADMIN_USER",
                newName: "UserName");
        }
    }
}
