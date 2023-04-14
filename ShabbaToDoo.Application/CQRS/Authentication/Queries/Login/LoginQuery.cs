using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.CQRS.Authentication.Common;

namespace ShabbaToDoo.Application.CQRS.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
