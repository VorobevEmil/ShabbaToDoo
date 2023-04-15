using ErrorOr;
using MediatR;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Project.Queries.UserProjects
{
    public record UserProjectsQuery
    () : IRequest<ErrorOr<List<ProjectTodo>>>;
}
