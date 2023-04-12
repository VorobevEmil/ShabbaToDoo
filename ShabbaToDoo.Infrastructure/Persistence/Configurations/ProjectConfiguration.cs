using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            ConfigureProjectsTable(builder);
        }

        private void ConfigureProjectsTable(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Details)
                .HasMaxLength(100);

            builder.HasOne(left => left.Author)
                .WithMany(right => right.AuthorProjects)
                .HasForeignKey(x => x.AuthorId);

            builder.HasMany(left => left.TodoItems)
                .WithOne(right => right.Project)
                .HasForeignKey(x => x.ProjectId);

            builder.HasMany(left => left.Users)
                .WithMany(right => right.Projects)
                .UsingEntity(join => join.ToTable("UserProjects"));
        }
    }
}