using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Authentication.Common;

namespace ShabbaToDoo.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
