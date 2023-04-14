using Microsoft.AspNetCore.Identity;

namespace ShabbaToDoo.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public List<ProjectTodo> Projects { get; set; } = default!;
        public List<ProjectTodo> AuthorProjects { get; set; } = default!;
        public List<TodoItem> Todos { get; set; } = default!;
        public List<TodoComment> Comments { get; set; } = default!;
    }
}