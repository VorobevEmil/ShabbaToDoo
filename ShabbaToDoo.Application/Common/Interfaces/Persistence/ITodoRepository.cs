using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.Common.Interfaces.Persistence
{
    public interface ITodoRepository
    {
        IQueryable<TodoItem> TodoItems { get; }
        Task<TodoItem?> GetByIdAsync(Guid projectId, Guid todoId, bool includeAuthor = false);
        Task<List<TodoItem>> GetTodosByProjectId(Guid projectId);
        Task<TodoItem> CreateAsync(TodoItem todo);
        Task<bool> UpdateAsync(TodoItem todo);
        Task<bool> DeleteAsync(TodoItem todo);
    }
}
