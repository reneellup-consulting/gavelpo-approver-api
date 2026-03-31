using ErrorOr;
using GavelMobilePoApprover.Application.Outstanding.Common;
using GavelMobilePoApprover.Application.Outstanding.Query.Count;
using GavelMobilePoApprover.Contracts.Order;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GavelMobilePoApprover.Api.Controllers;

[Route("api/count")]
[Authorize]
public class CountController : ApiController {

    private readonly ISender _mediator;

    private readonly IMapper _mapper;

    public CountController(ISender mediator, IMapper mapper) {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetCount(OutstandingCountRequest request) {

        var query = _mapper.Map<OutstandingCountQuery>(request);

        ErrorOr<OutstandingCountResult> outstandingCountResult = await _mediator.Send(query);

        return outstandingCountResult.Match(
                       outstandingCountResult => Ok(_mapper.Map<OutstandingCountResponse>(outstandingCountResult)),
                                  errors => Problem(errors));
    }
}
