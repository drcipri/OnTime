using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnTime.Models.DatabaseConfigs
{
    public class AppointmentConfigs : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");
            builder.Property(i => i.Id).HasColumnType("int").IsRequired().UseIdentityColumn();
            builder.Property(o => o.Objective).HasColumnType("varchar").HasMaxLength(300).IsRequired();
            builder.Property(d => d.AppointmentDateTime).IsRequired();
            builder.Property(d => d.PostDateTime).IsRequired();
            builder.Property(r => r.Reason).HasColumnType("varchar").HasMaxLength(500).HasDefaultValue("-");
            builder.Property(a => a.AdditionalInfo).HasColumnType("varchar").HasMaxLength(200).HasDefaultValue("-");
            builder.HasOne(c => c.Classification).WithMany().HasForeignKey(c => c.ClassificationId).OnDelete(DeleteBehavior.NoAction); //configure foreign key with no map property on the Classification Class
        }
    }
}
