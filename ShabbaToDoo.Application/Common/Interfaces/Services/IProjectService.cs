using ErrorOr;
using ShabbaToDoo.Application.CQRS.Project.Commands.AddMembers;
using ShabbaToDoo.Application.CQRS.Project.Commands.Create;
using ShabbaToDoo.Application.CQRS.Project.Commands.Update;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.Common.Interfaces.Services
{
    public interface IProjectService
    {
        Task<ErrorOr<List<ProjectTodo>>> GetProjectsAvailableUserAsync();
        Task<ErrorOr<List<ProjectTodo>>> GetUserProjectsAsync();
        Task<ErrorOr<ProjectTodo>> GetProjectByIdAsync(Guid id);
        Task<ErrorOr<ProjectTodo>> CreateAsync(CreateProjectCommand request);
        Task<ErrorOr<bool>> UpdateAsync(UpdateProjectCommand request);
        Task<ErrorOr<bool>> AddMembersAsync(AddMembersCommand request);
        Task<ErrorOr<bool>> DeleteAsync(Guid id);
    }
}
