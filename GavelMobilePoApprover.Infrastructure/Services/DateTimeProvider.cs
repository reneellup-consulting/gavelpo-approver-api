using GavelMobilePoApprover.Application.Common.Interfaces.Services;

namespace GavelMobilePoApprover.Infrastructure.Services;
public class DateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;
}