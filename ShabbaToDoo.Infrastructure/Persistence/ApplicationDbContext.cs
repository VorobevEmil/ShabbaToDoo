using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShabbaToDoo.Domain.Entities;
using System.Reflection;

namespace ShabbaToDoo.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Project> Projects { get; set; } = default!;
        public DbSet<TodoItem> TodoItems { get; set; } = default!;
        public DbSet<TodoComment> TodoComments { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ApplyConfigurationForTables(builder);
            base.OnModelCreating(builder);
        }

        private void ApplyConfigurationForTables(ModelBuilder builder)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            var configurationTypes = types
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition &&
                            t.GetInterfaces().Any(i => i.IsGenericType &&
                                                       i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .ToList();

            foreach (var configurationType in configurationTypes)
            {
                dynamic configuration = Activator.CreateInstance(configurationType)!;
                builder.ApplyConfiguration(configuration);
            }
        }
    }
}