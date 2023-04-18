using ErrorOr;
using MediatR;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Todo.Queries.TodoById
{
    public record TodoByIdQuery
    (
        Guid ProjectId, 
        Guid TodoId
    ) : IRequest<ErrorOr<TodoItem>>;
}
