using BuberDinner.Application.Authentication.Common;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Api.Common.Mapping;

using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Mapster;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);

        // Custom mapping for UserId to Guid
        config.NewConfig<UserId, Guid>()
            .MapWith(src => src.Value); // Assuming UserId has a property 'Value' of type Guid
    }
}