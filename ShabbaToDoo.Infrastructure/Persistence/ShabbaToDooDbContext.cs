using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShabbaToDoo.Domain.Entities;
using System.Reflection;

namespace ShabbaToDoo.Infrastructure.Persistence
{
    public class ShabbaToDooDbContext : IdentityDbContext<ApplicationUser>
    {
        public ShabbaToDooDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ProjectTodo> Projects { get; set; } = default!;
        public DbSet<TodoItem> TodoItems { get; set; } = default!;
        public DbSet<TodoComment> TodoComments { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ShabbaToDooDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}