using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Services;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Project.Queries.ProjectById
{
    public class ProjectByIdQueryHandler : IRequestHandler<ProjectByIdQuery, ErrorOr<ProjectTodo>>
    {
        private readonly IProjectService _service;

        public ProjectByIdQueryHandler(IProjectService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<ProjectTodo>> Handle(ProjectByIdQuery query, CancellationToken cancellationToken)
        {
            return await _service.GetProjectById(query.Id);
        }
    }
}
