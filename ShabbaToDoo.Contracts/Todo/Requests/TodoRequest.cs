namespace ShabbaToDoo.Contracts.Todo.Requests
{
    public record TodoRequest
    (
        string Title,
        string? Description,
        DateTime? Deadline,
        bool IsImportant
    );
}
