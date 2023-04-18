using ErrorOr;
using MediatR;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Todo.Queries.TodosForProject
{
    public record TodosForProjectQuery
    (
        Guid ProjectId
    ) : IRequest<ErrorOr<List<TodoItem>>>;
}
