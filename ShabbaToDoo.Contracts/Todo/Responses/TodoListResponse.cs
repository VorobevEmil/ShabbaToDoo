using ShabbaToDoo.Contracts.User.Responses;

namespace ShabbaToDoo.Contracts.Todo.Responses
{
    public record TodoListResponse
    (
        Guid Id,
        string Title,
        UserResponse Author,
        bool IsComplete,
        bool IsImportant,
        DateTime? Deadline,
        DateTime CreationDate
    );
}
