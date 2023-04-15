using ErrorOr;
using MediatR;

namespace ShabbaToDoo.Application.CQRS.Project.Commands.Update
{
    public record UpdateProjectCommand
    (
        Guid Id,
        string Title,
        string? Details
    ) : IRequest<ErrorOr<bool>>;
}
