using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnTime.Models.Migrations
{
    public partial class ModifyForeignKeyConstraintName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Classifications_ClassificationId",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Classifications",
                table: "Appointments",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Classifications",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Classifications_ClassificationId",
                table: "Appointments",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id");
        }
    }
}
