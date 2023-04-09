using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Authentication.Common;

namespace ShabbaToDoo.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string UserName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
