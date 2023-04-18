using ErrorOr;
using Microsoft.AspNetCore.Http;
using ShabbaToDoo.Application.Common.Extensions;
using ShabbaToDoo.Application.Common.Interfaces.Persistence;
using ShabbaToDoo.Application.Common.Interfaces.Services;
using ShabbaToDoo.Application.CQRS.Todo.Commands.Create;
using ShabbaToDoo.Application.CQRS.Todo.Commands.Delete;
using ShabbaToDoo.Application.CQRS.Todo.Commands.Update;
using ShabbaToDoo.Application.CQRS.Todo.Commands.UpdateIsComplete;
using ShabbaToDoo.Application.CQRS.Todo.Queries.TodoById;
using ShabbaToDoo.Application.CQRS.Todo.Queries.TodosForProject;
using ShabbaToDoo.Domain.Common.Errors;
using ShabbaToDoo.Domain.Entities;
using ShabbaToDoo.Infrastructure.Helpers;
using ShabbaToDoo.Infrastructure.Persistence.Repositories.Extensions;

namespace ShabbaToDoo.Infrastructure.Services
{
    public class TodoService : ITodoService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITodoRepository _todoRepository;
        private readonly string _userId;

        public TodoService(IProjectRepository projectRepository, ITodoRepository todoRepository, IHttpContextAccessor contextAccessor)
        {
            _projectRepository = projectRepository;
            _todoRepository = todoRepository;

            _userId = contextAccessor.HttpContext!.User.GetUserId();
        }

        public async Task<ErrorOr<TodoItem?>> GetByIdAsync(TodoByIdQuery query)
        {
            var error = await CheckUserHasRightToProjectAsync(query.ProjectId);
            if (error != default)
                return error;

            var todo = await _todoRepository.GetByIdAsync(query.ProjectId, query.TodoId, true);
            if (todo is null)
                return Errors.Todo.NotFound;

            return todo;
        }

        public async Task<ErrorOr<List<TodoItem>>> GetTodosByProjectIdAsync(TodosForProjectQuery query)
        {
            var error = await CheckUserHasRightToProjectAsync(query.ProjectId);
            if (error != default)
                return error;

            return await _todoRepository.GetTodosByProjectId(query.ProjectId);
        }

        public async Task<ErrorOr<TodoItem>> CreateAsync(CreateTodoCommand request)
        {
            var error = await CheckUserHasRightToProjectAsync(request.Todo.ProjectId);
            if (error != default)
                return error;

            var todo = request.Todo;
            todo.CreationDate = DateTime.UtcNow;
            todo.AuthorId = _userId;
            return await _todoRepository.CreateAsync(todo);
        }

        public async Task<ErrorOr<bool>> UpdateAsync(UpdateTodoCommand request)
        {
            var todo = await _todoRepository.GetByIdAsync(request.ProjectId, request.TodoId);
            if (todo is null)
            {
                return Errors.Todo.NotFound;
            }

            todo.Title = request.Title;
            todo.Description = request.Description;
            todo.Deadline = request.Deadline;
            todo.IsImportant = request.IsImportant;

            return await _todoRepository.UpdateAsync(todo);
        }

        public async Task<ErrorOr<bool>> DeleteAsync(DeleteTodoCommand request)
        {
            var error = await CheckUserHasRightToProjectAsync(request.ProjectId);
            if (error != default)
                return error;

            var todo = await _todoRepository.GetByIdAsync(request.ProjectId, request.TodoId);
            if (todo is null)
                return Errors.Todo.NotFound;

            return await _todoRepository.DeleteAsync(todo);
        }

        public async Task<ErrorOr<bool>> UpdateIsCompleteAsync(UpdateTodoIsCompleteCommand request)
        {
            var error = await CheckUserHasRightToProjectAsync(request.ProjectId);
            if (error != default)
                return error;

            var todo = await _todoRepository.GetByIdAsync(request.ProjectId, request.TodoId);
            if (todo is null)
                return Errors.Todo.NotFound;

            todo.IsComplete = request.IsComplete;

            return await _todoRepository.UpdateAsync(todo);
        }


        private async Task<Error> CheckUserHasRightToProjectAsync(Guid projectId)
        {
            var project = (await _projectRepository.GetByIdAsync(projectId, true, true))!;

            var error = ProjectAccessHelper.AccessProjectIfUserAuthorOrMembers(project, _userId);

            return error != default ? error : default;
        }
    }
}
