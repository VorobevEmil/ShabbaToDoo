namespace ShabbaToDoo.Contracts.Project.Responses
{
    public record ProjectListResponse
    (
        Guid Id,
        string Title,
        string? Details,
        string AuthorId,
        string FullName,
        DateTime CreationDate
    );
}
