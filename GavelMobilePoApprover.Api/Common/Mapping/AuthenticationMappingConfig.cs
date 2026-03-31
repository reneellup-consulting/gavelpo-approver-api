using GavelMobilePoApprover.Application.Authentication.Common;
using GavelMobilePoApprover.Application.Authentication.Queries.Login;
using GavelMobilePoApprover.Contracts.Authentication;
using Mapster;

namespace GavelMobilePoApprover.Api.Common.Mapping;
public class AuthenticationMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        // No neer for user registration for this app
        //config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}
