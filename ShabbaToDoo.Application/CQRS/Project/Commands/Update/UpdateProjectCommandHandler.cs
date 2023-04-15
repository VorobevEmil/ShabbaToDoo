using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Services;

namespace ShabbaToDoo.Application.CQRS.Project.Commands.Update
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, ErrorOr<bool>>
    {
        private readonly IProjectService _service;

        public UpdateProjectCommandHandler(IProjectService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<bool>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        { 
            return await _service.UpdateAsync(request);
        }
    }
}
