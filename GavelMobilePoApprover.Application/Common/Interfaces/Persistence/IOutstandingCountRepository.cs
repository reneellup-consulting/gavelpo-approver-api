using GavelMobilePoApprover.Domain;
using GavelMobilePoApprover.Domain.OutstandingCountAggregate;

namespace GavelMobilePoApprover.Application.Common.Interfaces.Persistence;
public interface IOutstandingCountRepository {
    OutstandingCount GetOutstandingCount();
}