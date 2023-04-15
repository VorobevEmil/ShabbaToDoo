using ErrorOr;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.Common.Interfaces.Persistence
{
    public interface IProjectRepository
    {
        IQueryable<ProjectTodo> Project { get; }
        Task<ProjectTodo?> GetByIdAsync(IQueryable<ProjectTodo> project, Guid id);
        Task<List<ProjectTodo>> GetProjectsAvailableUserAsync(IQueryable<ProjectTodo> project, string userId);
        Task<List<ProjectTodo>> GetUserProjectsAsync(IQueryable<ProjectTodo> project, string userId);
        Task<ProjectTodo> CreateAsync(ProjectTodo project);
        Task<bool> UpdateAsync(ProjectTodo project);
        Task<bool> AddMembersAsync(Guid id, List<string> requestUserIds);
        Task<bool> DeleteAsync(ProjectTodo project);
    }
}
