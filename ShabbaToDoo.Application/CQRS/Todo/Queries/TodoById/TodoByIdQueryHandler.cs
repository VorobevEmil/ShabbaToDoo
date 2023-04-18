using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Services;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Todo.Queries.TodoById
{
    public class TodoByIdQueryHandler : IRequestHandler<TodoByIdQuery, ErrorOr<TodoItem>>
    {
        private readonly ITodoService _service;

        public TodoByIdQueryHandler(ITodoService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<TodoItem>> Handle(TodoByIdQuery query, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(query)!;
        }
    }
}
