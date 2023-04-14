namespace ShabbaToDoo.Domain.Entities
{
    public class TodoItem
    {
        public Guid Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string? Details { get; set; } = default;
        public ProjectTodo Project { get; set; } = default!;
        public Guid ProjectId { get; set; } = default!;
        public ApplicationUser User { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public List<TodoComment> Comments { get; set; } = new();
        public bool IsComplete { get; set; } = default;
        public DateTime CreationDate { get; set; }
    }
}