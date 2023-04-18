using Mapster;
using ShabbaToDoo.Application.CQRS.Todo.Commands.Create;
using ShabbaToDoo.Application.CQRS.Todo.Commands.Update;
using ShabbaToDoo.Contracts.Todo.Requests;
using ShabbaToDoo.Contracts.Todo.Responses;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Api.Common.Mapping
{
    public class TodoMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TodoRequest, CreateTodoCommand>()
                .Map(dest => dest.Todo, src => src);

            config.NewConfig<TodoRequest, UpdateTodoCommand>();

            config.NewConfig<TodoItem, TodoByIdResponse>();
            config.NewConfig<TodoItem, TodoListResponse>();
        }
    }
}
