namespace ShabbaToDoo.Domain.Entities
{
    public class TodoComment
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public Guid TodoId { get; set; }
        public TodoItem Todo { get; set; } = default!;
        public ApplicationUser User { get; set; } = default!;
        public string UserId { get; set; } = default!;
    }
}