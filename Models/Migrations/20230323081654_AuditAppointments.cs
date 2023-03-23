using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnTime.Models.Migrations
{
    public partial class AuditAppointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentsAudit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Objective = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentsAudit", x => x.Id);
                });

            //create trigger for audit on Appointments table -- CREATE
            migrationBuilder.Sql
                (@"
                     CREATE OR ALTER TRIGGER appointments_after_create
                     ON Appointments
                     AFTER INSERT
                     AS
                     BEGIN
	                     INSERT INTO AppointmentsAudit (ActionDate,ActionType,AppointmentDateTime,PostDateTime,Objective,Reason,AdditionalInfo,Classification,AppointmentId)
	                     SELECT GETDATE(),'CREATE',i.AppointmentDateTime,i.PostDateTime,i.Objective, i.Reason, i.AdditionalInfo, 
	                            (SELECT Name FROM Classifications c WHERE c.Id = i.ClassificationId), i.Id
                         FROM inserted i
                     END
                ");
            //create trigger for audit on Appointments table -- UPDATE
            migrationBuilder.Sql
                (@"
                     CREATE OR ALTER TRIGGER appointments_after_update
                     ON Appointments
                     AFTER UPDATE
                     AS
                     BEGIN
	                     INSERT INTO AppointmentsAudit (ActionDate,ActionType,AppointmentDateTime,PostDateTime,Objective,Reason,AdditionalInfo,Classification,AppointmentId)
	                     SELECT GETDATE(),'UPDATE',i.AppointmentDateTime,i.PostDateTime,i.Objective, i.Reason, i.AdditionalInfo, 
	                            (SELECT Name FROM Classifications c WHERE c.Id = i.ClassificationId), i.Id
                         FROM inserted i
                     END
                ");
            //create trigger for audit on Appointments table -- DELETE
            migrationBuilder.Sql
                (@"
                    CREATE TRIGGER appointments_after_delete
                    ON Appointments
                    AFTER DELETE
                    AS
                    BEGIN
	                    INSERT INTO AppointmentsAudit (ActionDate,ActionType,AppointmentDateTime,PostDateTime,Objective,Reason,AdditionalInfo,Classification,AppointmentId)
                    	SELECT GETDATE(),'DELETE',d.AppointmentDateTime,d.PostDateTime,d.Objective, d.Reason, d.AdditionalInfo, 
	                           (SELECT Name FROM Classifications c WHERE c.Id = d.ClassificationId), d.Id
                        FROM deleted d
                    END
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentsAudit");
            migrationBuilder.Sql("DROP TRIGGER appointments_after_create");
            migrationBuilder.Sql("DROP TRIGGER appointments_after_update");
            migrationBuilder.Sql("DROP TRIGGER appointments_after_delete");
        }
    }
}
