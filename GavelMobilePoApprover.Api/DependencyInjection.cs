using GavelMobilePoApprover.Api.Common.Errors;
using GavelMobilePoApprover.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GavelMobilePoApprover.Api;
public static class DependencyInjection {
    public static IServiceCollection AddPresentation(this IServiceCollection services) {
        services.AddControllers();
        
        services.AddSingleton<ProblemDetailsFactory, GavelMobilePoApproverProblemDetailsFactory>();

        services.AddMappings();

        return services;
    }
}
