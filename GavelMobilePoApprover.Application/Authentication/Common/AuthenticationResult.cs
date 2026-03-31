using GavelMobilePoApprover.Domain.UserAggregate;

namespace GavelMobilePoApprover.Application.Authentication.Common;
public record AuthenticationResult(
    User User,
    string Token
    );