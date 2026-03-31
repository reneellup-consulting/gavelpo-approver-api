using GavelMobilePoApprover.Application.Common.Interfaces.Persistence;
using GavelMobilePoApprover.Domain.OutstandingCountAggregate;

namespace GavelMobilePoApprover.Infrastructure.Persistence.Repositories;
public class OutstandingCountRepository : IOutstandingCountRepository {

    private readonly GavelMobilePoApproverDbContext _dbContext;

    private static readonly List<OutstandingCount> outstandingCounts = new();

    public OutstandingCountRepository(GavelMobilePoApproverDbContext dbContext) {
        _dbContext = dbContext;
    }

    public OutstandingCount? GetOutstandingCount() {
        return _dbContext.OutstandingCountViewModels.FirstOrDefault();
    }
}