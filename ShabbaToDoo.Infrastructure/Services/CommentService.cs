using ErrorOr;
using Microsoft.AspNetCore.Http;
using ShabbaToDoo.Application.Common.Extensions;
using ShabbaToDoo.Application.Common.Interfaces.Persistence;
using ShabbaToDoo.Application.Common.Interfaces.Services;
using ShabbaToDoo.Application.CQRS.Comment.Queries.CommentsForTodo;
using ShabbaToDoo.Domain.Entities;
using ShabbaToDoo.Domain.Common.Errors;
using ShabbaToDoo.Infrastructure.Helpers;
using ShabbaToDoo.Application.CQRS.Comment.Commands.Create;

namespace ShabbaToDoo.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITodoRepository _todoRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly string _userId;

        public CommentService(IProjectRepository projectRepository, ITodoRepository todoRepository, ICommentRepository commentRepository, IHttpContextAccessor contextAccessor)
        {
            _projectRepository = projectRepository;
            _todoRepository = todoRepository;
            _commentRepository = commentRepository;
            _userId = contextAccessor.HttpContext!.User.GetUserId();
        }

        public async Task<ErrorOr<TodoComment>> CreateAsync(CreateCommentCommand request)
        {
            var error = await CheckUserHasRightToProjectAsync(request.ProjectId);
            if (error != default)
                return error;

            var comment = request.Comment;
            comment.CreationDate = DateTime.UtcNow;
            comment.UserId = _userId;
            return await _commentRepository.CreateAsync(comment);
        }

        public async Task<ErrorOr<List<TodoComment>>> GetCommentsByProjectIdAndTodoIdAsync(CommentsForTodoQuery query)
        {
            var error = await CheckUserHasRightToProjectAsync(query.ProjectId);
            if (error != default)
                return error;

            var todo = await _todoRepository.GetByIdAsync(query.ProjectId, query.TodoId);
            if (todo is null)
                return Errors.Todo.NotFound;

            var comments = await _commentRepository.GetCommentsByTodoId(query.TodoId);

            return comments;
        }


        private async Task<Error> CheckUserHasRightToProjectAsync(Guid projectId)
        {
            var project = (await _projectRepository.GetByIdAsync(projectId, true, true))!;

            var error = ProjectAccessHelper.AccessProjectIfUserAuthorOrMembers(project, _userId);

            return error != default ? error : default;
        }
    }
}
