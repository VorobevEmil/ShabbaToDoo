using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShabbaToDoo.Application.CQRS.Todo.Commands.Create;
using ShabbaToDoo.Application.CQRS.Todo.Commands.Delete;
using ShabbaToDoo.Application.CQRS.Todo.Commands.Update;
using ShabbaToDoo.Application.CQRS.Todo.Commands.UpdateIsComplete;
using ShabbaToDoo.Application.CQRS.Todo.Queries.TodoById;
using ShabbaToDoo.Application.CQRS.Todo.Queries.TodosForProject;
using ShabbaToDoo.Contracts.Todo.Requests;
using ShabbaToDoo.Contracts.Todo.Responses;

namespace ShabbaToDoo.Api.Controllers
{
    [Route("project/{projectId}/todo")]
    public class TodoController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TodoController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodosForProject(Guid projectId)
        {
            var query = new TodosForProjectQuery(projectId);

            var todosForProjectResult = await _mediator.Send(query);

            return todosForProjectResult.Match(
                todosForProjectResponse => Ok(_mapper.Map<List<TodoListResponse>>(todosForProjectResponse)),
                Problem);
        }

        [HttpGet("{todoId}")]
        public async Task<IActionResult> GetTodoById(Guid projectId, Guid todoId)
        {
            var query = new TodoByIdQuery(projectId, todoId);

            var todoByIdResult = await _mediator.Send(query);

            return todoByIdResult.Match(
                todoByIdResponse => Ok(_mapper.Map<TodoByIdResponse>(todoByIdResponse)),
                Problem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoForProject(Guid projectId, TodoRequest request)
        {
            var command = _mapper.Map<CreateTodoCommand>(request);
            command.Todo.ProjectId = projectId;

            var createCommandResult = await _mediator.Send(command);

            return createCommandResult.Match(
                createTodoResponse => CreatedAtAction(nameof(GetTodoById), new { projectId = projectId, todoId = createTodoResponse.Id }, _mapper.Map<TodoListResponse>(createTodoResponse)),
                Problem);
        }

        [HttpPut("{todoId}")]
        public async Task<IActionResult> UpdateTodoForProject(Guid projectId, Guid todoId, TodoRequest request)
        {
            var command = _mapper.Map<UpdateTodoCommand>(request);
            command = command with { ProjectId = projectId, TodoId = todoId };

            var updateCommandResult = await _mediator.Send(command);

            return updateCommandResult.Match(
                updateCommandResponse => updateCommandResponse ? Ok() : BadRequest(),
            Problem);
        }

        [HttpPut("{todoId}/is-complete")]
        public async Task<IActionResult> UpdateIsComplete(Guid projectId, Guid todoId, [FromBody] bool isComplete)
        {
            var command = new UpdateTodoIsCompleteCommand(projectId, todoId, isComplete);

            var updateIsCompleteResult = await _mediator.Send(command);

            return updateIsCompleteResult.Match(
                updateCommandResponse => updateCommandResponse ? Ok() : BadRequest(),
                Problem);
        }

        [HttpDelete("{todoId}")]
        public async Task<IActionResult> DeleteTodoFromProject(Guid projectId, Guid todoId)
        {
            var command = new DeleteTodoCommand(projectId, todoId);

            var deleteCommandResult = await _mediator.Send(command);

            return deleteCommandResult.Match(
                deleteCommandResponse => deleteCommandResponse ? NoContent() : BadRequest(),
                Problem);
        }
    }
}
