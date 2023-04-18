namespace ShabbaToDoo.Domain.Entities
{
    public class TodoItem
    {
        public Guid Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string? Description { get; set; } = default;
        public ProjectTodo Project { get; set; } = default!;
        public Guid ProjectId { get; set; } = default!;
        public ApplicationUser Author { get; set; } = default!;
        public string AuthorId { get; set; } = default!;
        public List<TodoComment> Comments { get; set; } = new();
        public bool IsComplete { get; set; }
        public bool IsImportant { get; set; }
        public DateTime? Deadline { get; set; } = default!;
        public DateTime CreationDate { get; set; }
    }
}