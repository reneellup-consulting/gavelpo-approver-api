using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GavelMobilePoApprover.Api.Controllers;

[Route("api/history/")]
[Authorize]
public class PurchaseOrderHistoryController : ApiController {

    private readonly ISender _mediator;

    private readonly IMapper _mapper;

    public PurchaseOrderHistoryController(ISender mediator, IMapper mapper) {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult GetHistory() {
        return Ok(string.Format("hello from: api/history"));
    }

    [HttpGet("{id}")]
    public ActionResult GetHistoryById(int id) {
        return Ok(string.Format("hello from: api/history/{0}", id));
    }
}
