using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Services;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Project.Queries.ProjectsAvailableUser
{
    public class ProjectsAvailableUserQueryHandler : IRequestHandler<ProjectsAvailableUserQuery, ErrorOr<List<ProjectTodo>>>
    {
        private readonly IProjectService _service;

        public ProjectsAvailableUserQueryHandler(IProjectService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<List<ProjectTodo>>> Handle(ProjectsAvailableUserQuery query, CancellationToken cancellationToken)
        {
            return await _service.GetProjectsAvailableUserAsync();
        }
    }
}
