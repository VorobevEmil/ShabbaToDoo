namespace ShabbaToDoo.Contracts.Project.Requests
{
    public record ProjectAddMembersRequest
    (
        List<string> UserIds
    );
}
