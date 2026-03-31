using ErrorOr;
using GavelMobilePoApprover.Application.Authentication.Common;
using GavelMobilePoApprover.Application.Authentication.Queries.Login;
using GavelMobilePoApprover.Contracts.Authentication;
using GavelMobilePoApprover.Domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GavelMobilePoApprover.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController {
    private readonly ISender _mediator;

    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper) {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request) {
        var query = _mapper.Map<LoginQuery>(request);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials) {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout() {
        await Task.CompletedTask;
        return Ok();
    }
}
