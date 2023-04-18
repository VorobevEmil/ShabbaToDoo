using ErrorOr;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.Common.Interfaces.Persistence
{
    public interface IProjectRepository
    {
        IQueryable<ProjectTodo> Projects { get; }
        Task<ProjectTodo?> GetByIdAsync(Guid id, bool includeAuthor = false, bool includeMembers = false);
        Task<List<ProjectTodo>> GetProjectsAvailableUserAsync(string userId);
        Task<List<ProjectTodo>> GetUserProjectsAsync(string userId);
        Task<ProjectTodo> CreateAsync(ProjectTodo project);
        Task<bool> UpdateAsync(ProjectTodo project);
        Task<bool> AddMembersAsync(Guid id, List<string> requestUserIds);
        Task<bool> DeleteAsync(ProjectTodo project);
    }
}
