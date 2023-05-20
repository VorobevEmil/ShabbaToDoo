using ErrorOr;
using ShabbaToDoo.Application.CQRS.Comment.Commands.Create;
using ShabbaToDoo.Application.CQRS.Comment.Queries.CommentsForTodo;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.Common.Interfaces.Services
{
    public interface ICommentService
    {
        Task<ErrorOr<TodoComment>> CreateAsync(CreateCommentCommand request);
        Task<ErrorOr<List<TodoComment>>> GetCommentsByProjectIdAndTodoIdAsync(CommentsForTodoQuery query);
    }
}
