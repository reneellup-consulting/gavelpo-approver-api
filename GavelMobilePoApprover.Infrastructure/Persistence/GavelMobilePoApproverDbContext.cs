using GavelMobilePoApprover.Domain.OutstandingCountAggregate;
using GavelMobilePoApprover.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace GavelMobilePoApprover.Infrastructure.Persistence;
public class GavelMobilePoApproverDbContext : DbContext {
    public GavelMobilePoApproverDbContext(DbContextOptions<GavelMobilePoApproverDbContext> options)
        : base(options) { }

    public DbSet<User> UserViewModels { get; set; }

    public DbSet<OutstandingCount> OutstandingCountViewModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GavelMobilePoApproverDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
