using Mapster;
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
