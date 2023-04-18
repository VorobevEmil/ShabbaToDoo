using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Infrastructure.Persistence.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            ConfigureUsersTable(builder);
        }

        private void ConfigureUsersTable(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(left => left.AuthorProjects)
                .WithOne(right => right.Author)
                .HasForeignKey(x => x.AuthorId);

            builder.HasMany(left => left.Projects)
                .WithMany(right => right.Members)
                .UsingEntity(join => join.ToTable("UserProjects"));

            builder.HasMany(left => left.Todos)
                .WithOne(right => right.Author)
                .HasForeignKey(x => x.AuthorId);

            builder.HasMany(left => left.Comments)
                .WithOne(right => right.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}