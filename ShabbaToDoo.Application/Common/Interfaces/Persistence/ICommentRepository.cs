using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.Common.Interfaces.Persistence
{
    public interface ICommentRepository
    {
        Task<TodoComment> CreateAsync(TodoComment comment);

        Task<List<TodoComment>> GetCommentsByTodoId(Guid todoId);
    }
}
