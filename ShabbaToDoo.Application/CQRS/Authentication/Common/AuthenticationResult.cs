using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Authentication.Common
{
    public record AuthenticationResult(ApplicationUser User, string Token);
}
