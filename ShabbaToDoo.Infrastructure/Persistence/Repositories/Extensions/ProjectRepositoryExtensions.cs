using Microsoft.EntityFrameworkCore;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Infrastructure.Persistence.Repositories.Extensions
{
    public static class ProjectRepositoryExtensions
    {
        public static IQueryable<ProjectTodo> IncludeMembers(this IQueryable<ProjectTodo> project)
        {
            return project
                .Include(x => x.Members);
        }

        public static IQueryable<ProjectTodo> IncludeAuthor(this IQueryable<ProjectTodo> project)
        {
            return project
                .Include(x => x.Author);
        }

        public static IQueryable<ProjectTodo> IncludeTodoItems(this IQueryable<ProjectTodo> project)
        {
            return project
                .Include(x => x.TodoItems);
        }
    }
}