using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GavelMobilePoApprover.Api.Controllers;

[Route("api/order/")]
[Authorize]
public class PurchaseOrderEditableController : ApiController {

    private readonly ISender _mediator;

    private readonly IMapper _mapper;

    public PurchaseOrderEditableController(ISender mediator, IMapper mapper) {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{status}")]
    public ActionResult GetOrder(int status) {
        return Ok(string.Format("hello from: api/order/{0}", status));
    }

    [HttpGet("{status}/{id}")]
    public ActionResult GetOrderById(int status, int id) {
        return Ok(string.Format("hello from: api/order/{0}/{1}", status, id));
    }

    [HttpPost("{status}/{id}")]
    public ActionResult UpdateOrder(int status, int id) {
        return Ok(string.Format("update to: api/order/{0}/{1}", status, id));
    }
}
