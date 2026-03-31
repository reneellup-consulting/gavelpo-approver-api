using GavelMobilePoApprover.Domain.OutstandingCountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GavelMobilePoApprover.Infrastructure.Persistence.Configurations;
public class OutstandingCountConfiguration : IEntityTypeConfiguration<OutstandingCount> {
    public void Configure(EntityTypeBuilder<OutstandingCount> builder) {
        ConfigurationOutstandingCountView(builder);
    }

    private void ConfigurationOutstandingCountView(EntityTypeBuilder<OutstandingCount> builder) {

        builder.HasNoKey();
        builder.ToView("vOutstandingCount");

        builder.Property(e => e.Incoming).HasColumnName("Incoming");
        builder.Property(e => e.Pending).HasColumnName("Pending");
    }
}
