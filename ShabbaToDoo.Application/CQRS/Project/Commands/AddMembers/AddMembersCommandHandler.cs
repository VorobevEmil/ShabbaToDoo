using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Services;

namespace ShabbaToDoo.Application.CQRS.Project.Commands.AddMembers
{
    public class AddMembersCommandHandler : IRequestHandler<AddMembersCommand, ErrorOr<bool>>
    {
        private readonly IProjectService _service;

        public AddMembersCommandHandler(IProjectService service)
        {
            _service = service;
        }

        public async Task<ErrorOr<bool>> Handle(AddMembersCommand request, CancellationToken cancellationToken)
        {
            return await _service.AddMembersAsync(request);
        }
    }
}
