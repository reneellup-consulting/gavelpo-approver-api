using GavelMobilePoApprover.Application.Common.Interfaces.Authentication;
using GavelMobilePoApprover.Application.Common.Interfaces.Persistence;
using GavelMobilePoApprover.Application.Common.Interfaces.Services;
using GavelMobilePoApprover.Domain.OutstandingCountAggregate;
using GavelMobilePoApprover.Infrastructure.Authentication;
using GavelMobilePoApprover.Infrastructure.Persistence;
using GavelMobilePoApprover.Infrastructure.Persistence.Repositories;
using GavelMobilePoApprover.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GavelMobilePoApprover.Infrastructure;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration) {
        services.AddAuth(configuration)
            .AddPersistence();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    public static IServiceCollection AddPersistence(
        this IServiceCollection services) {

        services.AddDbContext<GavelMobilePoApproverDbContext>(
            options => options.UseSqlServer("Integrated Security=SSPI;Pooling=false;Data Source=(local);Initial Catalog=GVLLOCAL;TrustServerCertificate=true"));

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IOutstandingCountRepository, OutstandingCountRepository>();

        return services;
    }

    public static IServiceCollection AddAuth(
    this IServiceCollection services,
    ConfigurationManager configuration) {
        var JwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, JwtSettings);

        services.AddSingleton(Options.Create(JwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                options => options.TokenValidationParameters =
                    new TokenValidationParameters {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = JwtSettings.Issuer,
                        ValidAudience = JwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Secret)),
                    });

        return services;
    }
}
