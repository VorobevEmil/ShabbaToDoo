namespace ShabbaToDoo.Domain.Entities
{
    public class TodoItem
    {
        public Guid Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string? Details { get; set; }
        public Project Project { get; set; } = default!;
        public Guid ProjectId { get; set; } = default!;
        public List<TodoComment> Comments { get; set; } = default!;
        public bool IsComplete { get; set; }
        public DateTime CreationDate { get; set; }
    }
}