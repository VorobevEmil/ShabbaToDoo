using ErrorOr;
using Microsoft.AspNetCore.Http;
using ShabbaToDoo.Application.Common.Extensions;
using ShabbaToDoo.Application.Common.Interfaces.Persistence;
using ShabbaToDoo.Application.Common.Interfaces.Services;
using ShabbaToDoo.Application.CQRS.Project.Commands.AddMembers;
using ShabbaToDoo.Application.CQRS.Project.Commands.Create;
using ShabbaToDoo.Application.CQRS.Project.Commands.Update;
using ShabbaToDoo.Domain.Entities;
using ShabbaToDoo.Infrastructure.Helpers;
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
            return await _repository.GetProjectsAvailableUserAsync(_userId);
        }

        public async Task<ErrorOr<List<ProjectTodo>>> GetUserProjectsAsync()
        {
            return await _repository.GetUserProjectsAsync(_userId);
        }

        public async Task<ErrorOr<ProjectTodo>> GetProjectByIdAsync(Guid id)
        {
            var project = (await _repository.GetByIdAsync(id, true, true))!;

            var error = ProjectAccessHelper.AccessProjectIfUserAuthorOrMembers(project, _userId);
            if (error != default)
                return error;

            return project;
        }

        public async Task<ErrorOr<ProjectTodo>> CreateAsync(CreateProjectCommand request)
        {
            var project = request.Project;
            project.AuthorId = _userId;
            project.CreationDate = DateTime.UtcNow;
            return await _repository.CreateAsync(project);
        }

        public async Task<ErrorOr<bool>> UpdateAsync(UpdateProjectCommand request)
        {
            var project = (await _repository.GetByIdAsync(request.Id))!;

            var error = ProjectAccessHelper.AccessProjectIfUserAuthor(project, _userId);
            if (error != default)
                return error;

            project.Title = request.Title;
            project.Details = request.Details;

            return await _repository.UpdateAsync(project);
        }

        public async Task<ErrorOr<bool>> AddMembersAsync(AddMembersCommand request)
        {
            var project = await _repository.GetByIdAsync(request.Id);

            var error = ProjectAccessHelper.AccessProjectIfUserAuthor(project, _userId);
            if (error != default)
                return error;

            return await _repository.AddMembersAsync(request.Id, request.UserIds);
        }

        public async Task<ErrorOr<bool>> DeleteAsync(Guid id)
        {
            var project = (await _repository.GetByIdAsync(id))!;

            var error = ProjectAccessHelper.AccessProjectIfUserAuthor(project, _userId);
            if (error != default)
                return error;

            return await _repository.DeleteAsync(project);
        }
    }
}