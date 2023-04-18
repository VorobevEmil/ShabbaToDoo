using ErrorOr;
using ShabbaToDoo.Application.CQRS.Todo.Commands.Create;
using ShabbaToDoo.Application.CQRS.Todo.Commands.Delete;
using ShabbaToDoo.Application.CQRS.Todo.Commands.Update;
using ShabbaToDoo.Application.CQRS.Todo.Commands.UpdateIsComplete;
using ShabbaToDoo.Application.CQRS.Todo.Queries.TodoById;
using ShabbaToDoo.Application.CQRS.Todo.Queries.TodosForProject;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Application.Common.Interfaces.Services
{
    public interface ITodoService
    {
        Task<ErrorOr<TodoItem?>> GetByIdAsync(TodoByIdQuery query);
        Task<ErrorOr<List<TodoItem>>> GetTodosByProjectIdAsync(TodosForProjectQuery query);
        Task<ErrorOr<TodoItem>> CreateAsync(CreateTodoCommand request);
        Task<ErrorOr<bool>> UpdateAsync(UpdateTodoCommand request);
        Task<ErrorOr<bool>> DeleteAsync(DeleteTodoCommand request);
        Task<ErrorOr<bool>> UpdateIsCompleteAsync(UpdateTodoIsCompleteCommand request);
    }
}
