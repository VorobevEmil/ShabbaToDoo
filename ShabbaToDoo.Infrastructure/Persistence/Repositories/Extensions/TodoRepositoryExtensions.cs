using Microsoft.EntityFrameworkCore;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Infrastructure.Persistence.Repositories.Extensions
{
    public static class TodoRepositoryExtensions
    {
        public static IQueryable<TodoItem> IncludeAuthor(this IQueryable<TodoItem> project)
        {
            return project
                .Include(x => x.Author);
        }

        public static IQueryable<TodoItem> IncludeComments(this IQueryable<TodoItem> project)
        {
            return project
                .Include(x => x.Comments);
        }
    }
}