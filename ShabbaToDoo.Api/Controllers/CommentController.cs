using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShabbaToDoo.Application.CQRS.Comment.Commands.Create;
using ShabbaToDoo.Application.CQRS.Comment.Queries.CommentsForTodo;
using ShabbaToDoo.Contracts.Comment.Request;
using ShabbaToDoo.Contracts.Comment.Responses;

namespace ShabbaToDoo.Api.Controllers
{
    [Route("project/{projectId}/todo/{todoId}/comment")]
    public class CommentController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CommentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentsForTodo(Guid projectId, Guid todoId)
        {
            var query = new CommentsForTodoQuery(projectId, todoId);

            var commentsForTodoResult = await _mediator.Send(query);

            return commentsForTodoResult.Match(
                commentsForTodoResponse => Ok(_mapper.Map<List<CommentResponse>>(commentsForTodoResponse)),
                Problem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommentForTodo(Guid projectId, Guid todoId, CommentRequest request)
        {
            var command = new CreateCommentCommand(projectId, new()
            {
                Text = request.Text,
                TodoId = todoId,
            });

            var createCommandResult = await _mediator.Send(command);

            return createCommandResult.Match(
                createTodoResponse => StatusCode(201, _mapper.Map<CommentResponse>(createTodoResponse)),
                Problem);
        }
    }
}
