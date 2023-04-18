namespace ShabbaToDoo.Domain.Entities
{
    public class ProjectTodo
    {
        public Guid Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string? Details { get; set; } = default;
        public string AuthorId { get; set; } = default!;
        public ApplicationUser Author { get; set; } = default!;
        public List<ApplicationUser> Members { get; set; } = new();
        public List<TodoItem> TodoItems { get; set; } = new();
        public DateTime CreationDate { get; set; }
    }
}