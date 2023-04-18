using Microsoft.EntityFrameworkCore;
using ShabbaToDoo.Application.Common.Interfaces.Persistence;
using ShabbaToDoo.Domain.Entities;
using ShabbaToDoo.Infrastructure.Persistence.Repositories.Extensions;

namespace ShabbaToDoo.Infrastructure.Persistence.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ShabbaToDooDbContext _context;

        public TodoRepository(ShabbaToDooDbContext context)
        {
            _context = context;
        }

        public IQueryable<TodoItem> TodoItems => _context.TodoItems.AsQueryable();
        public async Task<TodoItem?> GetByIdAsync(Guid projectId, Guid todoId, bool includeAuthor = false)
        {
            var todoItems = _context.TodoItems.AsQueryable();

            if (includeAuthor)
                todoItems.IncludeAuthor();

            return await todoItems
                .FirstOrDefaultAsync(x => x.ProjectId == projectId && x.Id == todoId);
        }

        public async Task<List<TodoItem>> GetTodosByProjectId(Guid projectId)
        {
            return await _context.TodoItems
                .IncludeAuthor()
                .Where(x => x.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<TodoItem> CreateAsync(TodoItem todo)
        {
            await _context.TodoItems.AddAsync(todo);
            await _context.SaveChangesAsync();
            todo.Author = (await _context.Users.FindAsync(todo.AuthorId))!;
            return todo;
        }

        public async Task<bool> UpdateAsync(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(TodoItem todo)
        {
            _context.TodoItems.Remove(todo);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
