using ErrorOr;
using MediatR;

namespace ShabbaToDoo.Application.CQRS.Project.Commands.AddMembers
{
    public record AddMembersCommand
    (
        Guid Id,
        List<string> UserIds
    ) : IRequest<ErrorOr<bool>>;
}
