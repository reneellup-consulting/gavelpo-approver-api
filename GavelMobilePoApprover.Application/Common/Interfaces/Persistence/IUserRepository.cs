using GavelMobilePoApprover.Domain.UserAggregate;

namespace GavelMobilePoApprover.Application.Common.Interfaces.Persistence;
public interface IUserRepository {
    User? GetUserByEmail(string email);
}
