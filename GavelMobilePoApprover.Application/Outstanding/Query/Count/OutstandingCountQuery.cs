using ErrorOr;
using GavelMobilePoApprover.Application.Outstanding.Common;
using MediatR;

namespace GavelMobilePoApprover.Application.Outstanding.Query.Count;
public record OutstandingCountQuery() : IRequest<ErrorOr<OutstandingCountResult>>;