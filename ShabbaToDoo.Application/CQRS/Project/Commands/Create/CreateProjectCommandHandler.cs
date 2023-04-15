using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Services;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Project.Commands.Create
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ErrorOr<ProjectTodo>>
    {
        private readonly IProjectService _service;

        public CreateProjectCommandHandler(IProjectService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<ProjectTodo>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        { 
            return await _service.CreateAsync(request);
        }
    }
}
