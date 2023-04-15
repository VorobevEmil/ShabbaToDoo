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

        public IQueryable<ProjectTodo> Project => _context.Projects.AsQueryable();

        public async Task<ProjectTodo?> GetByIdAsync(IQueryable<ProjectTodo> project, Guid id)
        {
            return await project.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProjectTodo>> GetProjectsAvailableUserAsync(IQueryable<ProjectTodo> project, string userId)
        {
            return await project
                .Where(x => x.AuthorId == userId || x.Members.Any(t => t.Id == userId))
                .ToListAsync();
        }

        public async Task<List<ProjectTodo>> GetUserProjectsAsync(IQueryable<ProjectTodo> project, string userId)
        {
            return await project
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
                .Where(x => requestUserIds.Any(t => t ==x.Id))
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