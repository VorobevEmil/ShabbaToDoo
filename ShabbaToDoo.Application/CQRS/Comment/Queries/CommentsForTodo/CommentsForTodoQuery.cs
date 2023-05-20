using ErrorOr;
using MediatR;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Comment.Queries.CommentsForTodo
{
    public record CommentsForTodoQuery
    (
        Guid ProjectId,
        Guid TodoId
    ) : IRequest<ErrorOr<List<TodoComment>>>;
}
