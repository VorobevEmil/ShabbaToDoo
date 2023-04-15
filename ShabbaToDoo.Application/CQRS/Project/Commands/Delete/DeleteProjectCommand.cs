using ErrorOr;
using MediatR;

namespace ShabbaToDoo.Application.CQRS.Project.Commands.Delete
{
    public record DeleteProjectCommand(Guid Id) : IRequest<ErrorOr<bool>>;
}
