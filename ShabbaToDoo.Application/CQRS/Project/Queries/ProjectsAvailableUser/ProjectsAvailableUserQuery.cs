using ErrorOr;
using MediatR;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Project.Queries.ProjectsAvailableUser
{
    public record ProjectsAvailableUserQuery
    () : IRequest<ErrorOr<List<ProjectTodo>>>;
}
