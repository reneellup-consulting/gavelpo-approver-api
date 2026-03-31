using ErrorOr;
using GavelMobilePoApprover.Application.Authentication.Common;
using MediatR;

namespace GavelMobilePoApprover.Application.Authentication.Queries.Login;
public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
