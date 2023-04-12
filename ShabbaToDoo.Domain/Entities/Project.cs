namespace ShabbaToDoo.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string? Details { get; set; }
        public string AuthorId { get; set; } = default!;
        public ApplicationUser Author { get; set; } = default!;
        public List<ApplicationUser> Users { get; set; } = default!;
        public List<TodoItem> TodoItems { get; set; } = default!;
    }
}
