using ErrorOr;
using Microsoft.AspNetCore.Http;
using ShabbaToDoo.Application.Common.Extensions;
using ShabbaToDoo.Application.Common.Interfaces.Persistence;
using ShabbaToDoo.Application.Common.Interfaces.Services;
using ShabbaToDoo.Application.CQRS.Project.Commands.AddMembers;
using ShabbaToDoo.Application.CQRS.Project.Commands.Create;
using ShabbaToDoo.Application.CQRS.Project.Commands.Update;
using ShabbaToDoo.Domain.Common.Errors;
using ShabbaToDoo.Domain.Entities;
using ShabbaToDoo.Infrastructure.Persistence.Repositories.Extensions;

namespace ShabbaToDoo.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly string _userId;

        public ProjectService(IProjectRepository repository, IHttpContextAccessor contextAccessor)
        {
            _repository = repository;

            _userId = contextAccessor.HttpContext!.User.GetUserId();
        }

        public async Task<ErrorOr<List<ProjectTodo>>> GetProjectsAvailableUserAsync()
        {
            var projectQueryable = _repository.Project
                .IncludeAuthor()
                .IncludeMembers();

            return await _repository.GetProjectsAvailableUserAsync(projectQueryable, _userId);
        }

        public async Task<ErrorOr<List<ProjectTodo>>> GetUserProjectsAsync()
        {
            var projectQueryable = _repository.Project
                .IncludeAuthor();

            return await _repository.GetUserProjectsAsync(projectQueryable, _userId);
        }

        public async Task<ErrorOr<ProjectTodo>> GetProjectById(Guid id)
        {
            var projectQueryable = _repository.Project
                .IncludeAuthor()
                .IncludeMembers();

            var result = await AccessProjectIfUserHasRight<ProjectTodo>(id, projectQueryable, true);

            if (result.error.IsError)
            {
                return result.error;
            }

            var project = result.project;

            return project;
        }

        public async Task<ErrorOr<ProjectTodo>> CreateAsync(CreateProjectCommand request)
        {
            var project = request.Project;
            project.AuthorId = _userId;
            return await _repository.CreateAsync(project);
        }

        public async Task<ErrorOr<bool>> UpdateAsync(UpdateProjectCommand request)
        {
            var result = await AccessProjectIfUserHasRight<bool>(request.Id, _repository.Project);
            if (result.error.IsError)
            {
                return result.error;
            }

            var project = result.project;

            project.Title = request.Title;
            project.Details = request.Details;

            return await _repository.UpdateAsync(project);
        }

        public async Task<ErrorOr<bool>> AddMembersAsync(AddMembersCommand request)
        {
            var result = await AccessProjectIfUserHasRight<bool>(request.Id, _repository.Project);
            if (result.error.IsError)
            {
                return result.error;
            }

            return await _repository.AddMembersAsync(request.Id, request.UserIds);
        }

        public async Task<ErrorOr<bool>> DeleteAsync(Guid id)
        {
            var result = await AccessProjectIfUserHasRight<bool>(id, _repository.Project);
            if (result.error.IsError)
            {
                return result.error;
            }

            return await _repository.DeleteAsync(result.project);
        }

        private async Task<(ProjectTodo project, ErrorOr<T> error)> AccessProjectIfUserHasRight<T>(Guid id, IQueryable<ProjectTodo> projectQueryable, bool members = false)
        {
            var project = await _repository.GetByIdAsync(projectQueryable, id);

            if (project is null)
            {
                return (default!, Errors.Project<T>.NotFound);
            }

            if (project.AuthorId != _userId && (!members || project.Members.All(x => x.Id != _userId)))
            {
                return (default!, Errors.Project<T>.NoAccess);
            }

            return (project, default);
        }
    }
}