using ShabbaToDoo.Contracts.User.Responses;

namespace ShabbaToDoo.Contracts.Comment.Responses
{
    public record CommentResponse
    (
        Guid Id,
        string Text,
        Guid TodoId,
        UserResponse User,
        DateTime CreationDate
    );
}
