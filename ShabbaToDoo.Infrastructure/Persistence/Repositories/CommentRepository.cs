using Microsoft.EntityFrameworkCore;
using ShabbaToDoo.Application.Common.Interfaces.Persistence;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Infrastructure.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ShabbaToDooDbContext _context;

        public CommentRepository(ShabbaToDooDbContext context)
        {
            _context = context;
        }

        public async Task<TodoComment> CreateAsync(TodoComment comment)
        {
            await _context.TodoComments.AddAsync(comment);
            await _context.SaveChangesAsync();
            comment.User = (await _context.Users.FindAsync(comment.UserId))!;
            return comment;
        }

        public async Task<List<TodoComment>> GetCommentsByTodoId(Guid todoId)
        {
            return await _context.TodoComments
                .Where(x => x.TodoId == todoId)
                .ToListAsync();
        }
    }
}
