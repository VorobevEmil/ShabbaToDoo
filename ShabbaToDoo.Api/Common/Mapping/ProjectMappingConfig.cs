using Mapster;
using ShabbaToDoo.Application.CQRS.Project.Commands.AddMembers;
using ShabbaToDoo.Application.CQRS.Project.Commands.Create;
using ShabbaToDoo.Application.CQRS.Project.Commands.Update;
using ShabbaToDoo.Contracts.Project;
using ShabbaToDoo.Domain.Entities;

namespace ShabbaToDoo.Api.Common.Mapping
{
    public class ProjectMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProjectRequest, CreateProjectCommand>()
                .Map(dest => dest.Project, src => src);

            config.NewConfig<ProjectTodo, ProjectResponse>()
                .Map(dest => dest.FullName, src => $"{src.Author.FirstName} {src.Author.LastName}");

            config.NewConfig<ProjectRequest, UpdateProjectCommand>();

            config.NewConfig<ProjectTodo, ProjectUsersResponse>()
                .Map(dest => dest.Author, src => src.Author)
                .Map(dest => dest.Members, src => src.Members);

            config.NewConfig<ProjectAddMembersRequest, AddMembersCommand>();
        }
    }
}
