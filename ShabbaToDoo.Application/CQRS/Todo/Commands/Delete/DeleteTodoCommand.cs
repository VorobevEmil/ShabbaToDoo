using ErrorOr;
using MediatR;

namespace ShabbaToDoo.Application.CQRS.Todo.Commands.Delete
{
    public record DeleteTodoCommand
    (
        Guid ProjectId,
        Guid TodoId
    ) : IRequest<ErrorOr<bool>>;
}
