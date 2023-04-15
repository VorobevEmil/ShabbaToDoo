namespace ShabbaToDoo.Contracts.Project
{
    public record ProjectResponse
    (
        Guid Id,
        string Title,
        string? Details,
        string AuthorId,
        string FullName
    );
}
