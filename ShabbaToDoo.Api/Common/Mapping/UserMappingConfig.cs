using Mapster;
using ShabbaToDoo.Contracts.Common;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Api.Common.Mapping
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ApplicationUser, UserResponse>();
        }
    }
}
