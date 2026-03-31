using GavelMobilePoApprover.Domain.UserAggregate;

namespace GavelMobilePoApprover.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator {
    string GenerateToken(User user);
}