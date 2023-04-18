using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Services;

namespace ShabbaToDoo.Application.CQRS.Todo.Commands.Update
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, ErrorOr<bool>>
    {
        private readonly ITodoService _service;

        public UpdateTodoCommandHandler(ITodoService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<bool>> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            return await _service.UpdateAsync(request);
        }
    }
}
