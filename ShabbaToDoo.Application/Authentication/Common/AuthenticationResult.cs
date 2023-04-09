using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.Authentication.Common
{
    public record AuthenticationResult(ApplicationUser User, string Token);
}
