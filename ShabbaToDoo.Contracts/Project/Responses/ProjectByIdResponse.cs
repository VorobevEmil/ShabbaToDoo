using ShabbaToDoo.Contracts.User.Responses;

namespace ShabbaToDoo.Contracts.Project.Responses
{
    public record ProjectByIdResponse(
        Guid Id,
        string Title,
        string? Details,
        List<UserResponse> Members,
        UserResponse Author,
        DateTime CreationDate
    );
}
