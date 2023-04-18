using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Services;
using ShabbaToDoo.Application.CQRS.Todo.Queries.TodoById;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Todo.Queries.TodosForProject
{
    public class TodosForProjectQueryHandler : IRequestHandler<TodosForProjectQuery, ErrorOr<List<TodoItem>>>
    {
        private readonly ITodoService _service;

        public TodosForProjectQueryHandler(ITodoService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<List<TodoItem>>> Handle(TodosForProjectQuery query, CancellationToken cancellationToken)
        {
            return await _service.GetTodosByProjectIdAsync(query);
        }
    }
}
