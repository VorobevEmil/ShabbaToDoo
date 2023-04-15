using ErrorOr;
using MediatR;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Project.Commands.Create
{
    public record CreateProjectCommand
    (
        ProjectTodo Project
    ) : IRequest<ErrorOr<ProjectTodo>>;
}
