using MediatR;
using ErrorOr;
using ShabbaToDoo.Application.Common.Interfaces.Services;

namespace ShabbaToDoo.Application.CQRS.Project.Commands.Delete
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, ErrorOr<bool>>
    {
        private readonly IProjectService _service;

        public DeleteProjectCommandHandler(IProjectService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteAsync(request.Id);
        }
    }
}
