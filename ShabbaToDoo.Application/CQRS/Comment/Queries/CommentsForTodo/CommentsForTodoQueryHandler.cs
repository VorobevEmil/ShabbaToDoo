using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Services;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Comment.Queries.CommentsForTodo
{
    public class CommentsForTodoQueryHandler : IRequestHandler<CommentsForTodoQuery, ErrorOr<List<TodoComment>>>
    {
        private readonly ICommentService _service;

        public CommentsForTodoQueryHandler(ICommentService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<List<TodoComment>>> Handle(CommentsForTodoQuery query, CancellationToken cancellationToken)
        {
            return await _service.GetCommentsByProjectIdAndTodoIdAsync(query);
        }
    }
}
