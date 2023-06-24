using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace client_app_backend.Data.Migrations
{
    public partial class AddOwnerFieldInSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Survey",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Survey");
        }
    }
}
