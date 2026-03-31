using GavelMobilePoApprover.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GavelMobilePoApprover.Infrastructure.Persistence.Configurations;
public class UserConfigurations : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) {
        ConfigurationUserView(builder);
    }

    private void ConfigurationUserView(EntityTypeBuilder<User> builder) {
        // map the entity to the view
        builder.ToView("vPoApprover");

        // map the primary key
        builder.Property(e => e.Id).HasColumnName("Oid");
        builder.Property(e => e.No).HasColumnName("No");
        builder.Property(e => e.Name).HasColumnName("Name");
        builder.Property(e => e.Email).HasColumnName("Email");
        builder.Property(e => e.Password).HasColumnName("POPassword");
    }
}
