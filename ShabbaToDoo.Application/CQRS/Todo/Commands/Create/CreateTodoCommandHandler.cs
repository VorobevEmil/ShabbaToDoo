using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Services;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Todo.Commands.Create
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, ErrorOr<TodoItem>>
    {
        private readonly ITodoService _service;

        public CreateTodoCommandHandler(ITodoService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<TodoItem>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            return await _service.CreateAsync(request);
        }
    }
}
