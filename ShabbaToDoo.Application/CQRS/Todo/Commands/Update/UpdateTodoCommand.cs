using ErrorOr;
using MediatR;

namespace ShabbaToDoo.Application.CQRS.Todo.Commands.Update
{
    public record UpdateTodoCommand
    (
        Guid TodoId,
        Guid ProjectId,
        string Title,
        string? Description,
        DateTime? Deadline,
        bool IsImportant
    ) : IRequest<ErrorOr<bool>>;
}
