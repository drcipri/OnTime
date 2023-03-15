using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnTime.Models.Migrations
{
    public partial class PopulateClassifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Classifications VALUES ('Awaiting'), ('Succesfull'), ('Missed'), ('Canceled')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'"); //disable foreign key constraints
            migrationBuilder.Sql("DELETE FROM Classifications");
            migrationBuilder.Sql("EXEC sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'");//enable foreign key constraints
        }
    }
}
