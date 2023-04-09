using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user);
    }
}