using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Services;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.CQRS.Project.Queries.UserProjects
{
    public class UserProjectsQueryHandler : IRequestHandler<UserProjectsQuery, ErrorOr<List<ProjectTodo>>>
    {
        private readonly IProjectService _service;

        public UserProjectsQueryHandler(IProjectService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<List<ProjectTodo>>> Handle(UserProjectsQuery query, CancellationToken cancellationToken)
        {
            return await _service.GetUserProjectsAsync();
        }
    }
}
