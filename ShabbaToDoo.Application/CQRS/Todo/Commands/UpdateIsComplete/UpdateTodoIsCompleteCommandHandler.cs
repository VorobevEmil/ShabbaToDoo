using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Services;

namespace ShabbaToDoo.Application.CQRS.Todo.Commands.UpdateIsComplete
{
    public class UpdateTodoIsCompleteCommandHandler : IRequestHandler<UpdateTodoIsCompleteCommand, ErrorOr<bool>>
    {
        private readonly ITodoService _service;

        public UpdateTodoIsCompleteCommandHandler(ITodoService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<bool>> Handle(UpdateTodoIsCompleteCommand request, CancellationToken cancellationToken)
        {
            return await _service.UpdateIsCompleteAsync(request);
        }
    }
}
