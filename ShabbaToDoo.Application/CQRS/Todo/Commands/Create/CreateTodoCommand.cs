using ErrorOr;
using MediatR;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Todo.Commands.Create
{
    public record CreateTodoCommand
    (
        TodoItem Todo
    ) : IRequest<ErrorOr<TodoItem>>;
}