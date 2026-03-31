using GavelMobilePoApprover.Application.Common.Interfaces.Persistence;
using GavelMobilePoApprover.Domain.UserAggregate;

namespace GavelMobilePoApprover.Infrastructure.Persistence.Repositories;
public class UserRepository : IUserRepository {

    private readonly GavelMobilePoApproverDbContext _dbContext;

    private static readonly List<User> _users = new();

    public UserRepository(GavelMobilePoApproverDbContext dbContext) {
        _dbContext = dbContext;
    }

    public User? GetUserByEmail(string email) {
        return _dbContext.UserViewModels.SingleOrDefault(x => x.Email == email);
        //return _users.SingleOrDefault(x => x.Email == email);
    }
}
