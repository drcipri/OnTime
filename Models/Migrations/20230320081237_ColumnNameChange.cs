using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnTime.Models.Migrations
{
    public partial class ColumnNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddedDateTime",
                table: "Appointments",
                newName: "PostDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostDateTime",
                table: "Appointments",
                newName: "AddedDateTime");
        }
    }
}
