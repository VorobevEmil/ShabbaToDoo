using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Infrastructure.Persistence.Configurations
{
    public class TodoCommentConfiguration : IEntityTypeConfiguration<TodoComment>
    {
        public void Configure(EntityTypeBuilder<TodoComment> builder)
        {
            ConfigureTodoCommentsTable(builder);
        }

        private void ConfigureTodoCommentsTable(EntityTypeBuilder<TodoComment> builder)
        {
            builder.ToTable("TodoComments");

            builder.HasKey(t => t.Id);

            builder.Property(x => x.Text)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(left => left.Todo)
                .WithMany(right => right.Comments)
                .HasForeignKey(x => x.TodoId);
        }
    }
}
