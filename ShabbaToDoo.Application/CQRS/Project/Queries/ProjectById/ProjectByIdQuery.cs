using ErrorOr;
using MediatR;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Project.Queries.ProjectById
{
    public record ProjectByIdQuery
    (
        Guid Id
    ) : IRequest<ErrorOr<ProjectTodo>>;
}
