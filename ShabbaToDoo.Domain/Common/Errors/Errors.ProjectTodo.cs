using ErrorOr;

namespace ShabbaToDoo.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Project<T>
        {
            public static Error NotFound => Error.NotFound(
                code: "Project.NotFound",
                description: "Project not found.");

            public static ErrorOr<T> NoAccess => Error.Custom(
                type: 403,
                code: "Project.NoAccess",
                description: "The user does not have access to the project.");
        }
    }
}
