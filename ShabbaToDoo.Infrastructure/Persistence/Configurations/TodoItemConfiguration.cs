using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Infrastructure.Persistence.Configurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            ConfigureTodoItemsTable(builder);
        }

        private void ConfigureTodoItemsTable(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("TodoItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Details)
                .HasMaxLength(100);

            builder.Property(x => x.CreationDate)
                .IsRequired();

            builder.HasOne(left => left.Project)
                .WithMany(right => right.TodoItems)
                .HasForeignKey(x => x.ProjectId);

            builder.HasMany(left => left.Comments)
                .WithOne(right => right.Todo)
                .HasForeignKey(x => x.TodoId);
        }
    }
}