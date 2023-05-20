using Mapster;
using ShabbaToDoo.Application.CQRS.Comment.Commands.Create;
using ShabbaToDoo.Contracts.Comment.Request;
using ShabbaToDoo.Contracts.Comment.Responses;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Api.Common.Mapping
{
    public class CommentMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TodoComment, CommentResponse>();
        }
    }
}
