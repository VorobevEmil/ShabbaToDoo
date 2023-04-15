namespace ShabbaToDoo.Contracts.Project
{
    public record ProjectAddMembersRequest
    (
        Guid Id,
        List<string> UserIds
    );
}
