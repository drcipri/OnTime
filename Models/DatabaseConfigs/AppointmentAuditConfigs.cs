using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnTime.Models.DatabaseConfigs
{
    public class AppointmentAuditConfigs : IEntityTypeConfiguration<AppointmentAudit>
    {
        public void Configure(EntityTypeBuilder<AppointmentAudit> builder)
        {
            builder.ToTable("ApointmentsAudit");
            builder.Property(i => i.Id).HasColumnType("int").IsRequired().UseIdentityColumn();
            builder.Property(a => a.ActionDate).IsRequired();
            builder.Property(a => a.ActionType).HasColumnType("varchar").HasMaxLength(40).IsRequired();
            builder.Property(d => d.AppointmentDateTime).IsRequired();
            builder.Property(d => d.PostDateTime).IsRequired();
            builder.Property(o => o.Objective).HasColumnType("varchar").HasMaxLength(300).IsRequired();
            builder.Property(r => r.Reason).HasColumnType("varchar").HasMaxLength(500).HasDefaultValue("-");
            builder.Property(a => a.AdditionalInfo).HasColumnType("varchar").HasMaxLength(200).HasDefaultValue("-");
            builder.Property(c => c.Classification).HasColumnType("varchar").HasMaxLength(40).HasDefaultValue("-");
            builder.Property(i => i.AppointmentId).HasColumnType("int").IsRequired();
        }
    }
}
