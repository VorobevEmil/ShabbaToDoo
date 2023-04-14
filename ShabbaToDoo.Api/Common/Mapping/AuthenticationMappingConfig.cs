using Mapster;
using ShabbaToDoo.Application.CQRS.Authentication.Commands.Register;
using ShabbaToDoo.Application.CQRS.Authentication.Common;
using ShabbaToDoo.Application.CQRS.Authentication.Queries.Login;
using ShabbaToDoo.Contracts.Authentication;

namespace ShabbaToDoo.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);
        }
    }
}
