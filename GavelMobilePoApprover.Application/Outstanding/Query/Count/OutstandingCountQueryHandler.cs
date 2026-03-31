using ErrorOr;
using GavelMobilePoApprover.Application.Common.Interfaces.Persistence;
using GavelMobilePoApprover.Application.Outstanding.Common;
using GavelMobilePoApprover.Domain.OutstandingCountAggregate;
using MediatR;

namespace GavelMobilePoApprover.Application.Outstanding.Query.Count;
public class OutstandingCountQueryHandler : IRequestHandler<OutstandingCountQuery, ErrorOr<OutstandingCountResult>> {

    private readonly IOutstandingCountRepository _outstandingCountRepository;

    public OutstandingCountQueryHandler(IOutstandingCountRepository outstandingCountRepository) {
        _outstandingCountRepository = outstandingCountRepository;
    }

    public async Task<ErrorOr<OutstandingCountResult>> Handle(OutstandingCountQuery request, CancellationToken cancellationToken) {
        await Task.CompletedTask;

        OutstandingCount outstandingCount = _outstandingCountRepository.GetOutstandingCount();

        return new OutstandingCountResult(outstandingCount.Incoming, outstandingCount.Pending);
    }
}
