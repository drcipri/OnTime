using Microsoft.EntityFrameworkCore;
using OnTime.Models.DatabaseConfigs;

namespace OnTime.Models
{
    public class OnTimeAppointmentsDbContext: DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<AppointmentAudit> AppointmentsAudit { get; set; }  
        public OnTimeAppointmentsDbContext(DbContextOptions<OnTimeAppointmentsDbContext> options) 
            :base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppointmentConfigs());
            modelBuilder.ApplyConfiguration(new ClassificationConfigs());
        }
    }
}
