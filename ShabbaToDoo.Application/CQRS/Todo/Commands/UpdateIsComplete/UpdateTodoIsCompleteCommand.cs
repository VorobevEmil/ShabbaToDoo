using ErrorOr;
using MediatR;

namespace ShabbaToDoo.Application.CQRS.Todo.Commands.UpdateIsComplete
{
    public record UpdateTodoIsCompleteCommand
    (
        Guid ProjectId,
        Guid TodoId,
        bool IsComplete
    ) : IRequest<ErrorOr<bool>>;
}
