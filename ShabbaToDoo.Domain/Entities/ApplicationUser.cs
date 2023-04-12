using Microsoft.AspNetCore.Identity;

namespace ShabbaToDoo.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public List<Project> Projects { get; set; } = default!;
        public List<Project> AuthorProjects { get; set; } = default!;
    }
}