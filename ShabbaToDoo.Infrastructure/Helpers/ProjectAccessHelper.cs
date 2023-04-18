using ShabbaToDoo.Domain.Entities;
using ErrorOr;
using ShabbaToDoo.Domain.Common.Errors;

namespace ShabbaToDoo.Infrastructure.Helpers
{
    public static class ProjectAccessHelper
    {
        public static Error AccessProjectIfUserAuthor(ProjectTodo? project, string userId)
            => AccessProjectIfUserHasRight(project, userId, CheckAuthorProject);

        public static Error AccessProjectIfUserMembers(ProjectTodo? project, string userId)
            => AccessProjectIfUserHasRight(project, userId, CheckMembersProject);

        public static Error AccessProjectIfUserAuthorOrMembers(ProjectTodo? project, string userId)
            => AccessProjectIfUserHasRight(project, userId, CheckAuthorOrMembersProject);

        private static Error AccessProjectIfUserHasRight(ProjectTodo? project, string userId, Func<ProjectTodo, string, bool> hasUserRight)
        {
            if (project is null)
            {
                return Errors.Project.NotFound;
            }

            if (hasUserRight(project, userId))
            {
                return Errors.Project.NoAccess;
            }

            return default;
        }

        private static bool CheckAuthorOrMembersProject(ProjectTodo project, string userId)
            => CheckAuthorProject(project, userId) && CheckMembersProject(project, userId);

        private static bool CheckAuthorProject(ProjectTodo project, string userId)
            => project.AuthorId != userId;

        private static bool CheckMembersProject(ProjectTodo project, string userId)
            => project.Members.All(x => x.Id != userId);
    }
}
