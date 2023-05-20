using ErrorOr;
using MediatR;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Comment.Commands.Create
{
    public record CreateCommentCommand
    (
        Guid ProjectId,
        TodoComment Comment
    ) : IRequest<ErrorOr<TodoComment>>;
}
