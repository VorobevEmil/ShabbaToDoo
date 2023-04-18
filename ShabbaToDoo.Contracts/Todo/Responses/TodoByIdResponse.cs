using ShabbaToDoo.Contracts.User.Responses;

namespace ShabbaToDoo.Contracts.Todo.Responses
{
    public record TodoByIdResponse
    (
        Guid Id,
        string Title,
        string? Description,
        UserResponse Author,
        bool IsComplete,
        bool IsImportant,
        DateTime? Deadline,
        DateTime CreationDate
    );
}