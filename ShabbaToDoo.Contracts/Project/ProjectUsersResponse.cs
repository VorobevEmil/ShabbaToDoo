using ShabbaToDoo.Contracts.Common;

namespace ShabbaToDoo.Contracts.Project
{
    public record ProjectUsersResponse(
        Guid Id,
        string Title,
        string? Details,
        List<UserResponse> Members,
        UserResponse Author
    );
}
