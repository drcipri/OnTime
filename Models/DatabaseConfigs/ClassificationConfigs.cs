using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnTime.Models.DatabaseConfigs
{
    public class ClassificationConfigs : IEntityTypeConfiguration<Classification>
    {
        public void Configure(EntityTypeBuilder<Classification> builder)
        {
            builder.ToTable("Classifications");
            builder.Property(i => i.Id).HasColumnType("int").IsRequired().UseIdentityColumn();
            builder.Property(i => i.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
        }
    }
}
