using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnTime.Models.Migrations
{
    public partial class ModifyAppointmentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Appointments",
                newName: "AppointmentDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDateTime",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDateTime",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentDateTime",
                table: "Appointments",
                newName: "DateTime");
        }
    }
}
