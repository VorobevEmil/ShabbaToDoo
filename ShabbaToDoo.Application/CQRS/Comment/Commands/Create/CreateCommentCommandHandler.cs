using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Services;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Comment.Commands.Create
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, ErrorOr<TodoComment>>
    {
        private readonly ICommentService _service;

        public CreateCommentCommandHandler(ICommentService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<TodoComment>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            return await _service.CreateAsync(request);
        }
    }
}
