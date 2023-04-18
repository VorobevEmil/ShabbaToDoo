using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Services;

namespace ShabbaToDoo.Application.CQRS.Todo.Commands.Delete
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, ErrorOr<bool>>
    {
        private readonly ITodoService _service;

        public DeleteTodoCommandHandler(ITodoService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteAsync(request);
        }
    }
}
