using Microsoft.EntityFrameworkCore;
using ShabbaToDoo.Application.Common.Interfaces.Persistence;
using ShabbaToDoo.Domain.Entities;
using ShabbaToDoo.Infrastructure.Persistence.Repositories.Extensions;

namespace ShabbaToDoo.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ShabbaToDooDbContext _context;

        public ProjectRepository(ShabbaToDooDbContext context)
        {
            _context = context;
        }

        public IQueryable<ProjectTodo> Projects => _context.Projects.AsQueryable();

        public async Task<ProjectTodo?> GetByIdAsync(Guid id, bool includeAuthor = false, bool includeMembers = false)
        {
            var projects = _context.Projects.AsQueryable();

            if (includeAuthor)
                projects = projects.IncludeAuthor();

            if (includeMembers)
                projects = projects.IncludeMembers();

            return await projects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProjectTodo>> GetProjectsAvailableUserAsync(string userId)
        {
            return await _context.Projects
                .IncludeAuthor()
                .IncludeMembers()
                .Where(x => x.AuthorId == userId || x.Members.Any(t => t.Id == userId))
                .ToListAsync();
        }

        public async Task<List<ProjectTodo>> GetUserProjectsAsync(string userId)
        {
            return await _context.Projects
                .IncludeAuthor()
                .Where(x => x.AuthorId == userId)
                .ToListAsync();
        }

        public async Task<ProjectTodo> CreateAsync(ProjectTodo project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            project.Author = (await _context.Users.FindAsync(project.AuthorId))!;
            return project;
        }

        public async Task<bool> UpdateAsync(ProjectTodo project)
        {
            _context.Entry(project).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddMembersAsync(Guid id, List<string> requestUserIds)
        {
            var project = await _context.Projects
                 .Include(x => x.Members)
                 .FirstAsync(x => x.Id == id);

            var users = await _context.Users
                .Where(x => requestUserIds.Any(t => t == x.Id))
                .ToListAsync();

            project.Members.AddRange(users);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(ProjectTodo project)
        {
            _context.Projects.Remove(project);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}