﻿using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShabbaToDoo.Application.CQRS.Project.Commands.AddMembers;
using ShabbaToDoo.Application.CQRS.Project.Commands.Create;
using ShabbaToDoo.Application.CQRS.Project.Commands.Delete;
using ShabbaToDoo.Application.CQRS.Project.Commands.Update;
using ShabbaToDoo.Application.CQRS.Project.Queries.ProjectById;
using ShabbaToDoo.Application.CQRS.Project.Queries.ProjectsAvailableUser;
using ShabbaToDoo.Application.CQRS.Project.Queries.UserProjects;
using ShabbaToDoo.Contracts.Project.Requests;
using ShabbaToDoo.Contracts.Project.Responses;

namespace ShabbaToDoo.Api.Controllers
{
    [Route("project")]
    public class ProjectController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProjectController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectsAvailableUser()
        {
            var command = new ProjectsAvailableUserQuery();

            var result = await _mediator.Send(command);

            return result.Match(
                projectResponse => Ok(_mapper.Map<List<ProjectListResponse>>(projectResponse)),
                Problem);
        }

        [HttpGet("user-projects")]
        public async Task<IActionResult> UserProjects()
        {
            var command = new UserProjectsQuery();

            var result = await _mediator.Send(command);

            return result.Match(
                projectResponse => Ok(_mapper.Map<List<ProjectListResponse>>(projectResponse)),
                Problem);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var command = new ProjectByIdQuery(id);

            var result = await _mediator.Send(command);

            return result.Match(
                projectResponse => Ok(_mapper.Map<ProjectByIdResponse>(projectResponse)),
                Problem);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectRequest request)
        {
            var command = _mapper.Map<CreateProjectCommand>(request);

            var createCommandResult = await _mediator.Send(command);

            return createCommandResult.Match(
                createProjectResponse => CreatedAtAction(nameof(GetProjectById), new { id = createProjectResponse.Id }, _mapper.Map<ProjectListResponse>(createProjectResponse)),
                Problem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProjectRequest request)
        {
            var command = _mapper.Map<UpdateProjectCommand>(request);
            command = command with { Id = id };
            var updateResult = await _mediator.Send(command);

            return updateResult.Match(
                updateProjectResponse => updateProjectResponse ? Ok() : BadRequest(),
                Problem);
        }

        [HttpPut("add-members/{id}")]
        public async Task<IActionResult> AddMembers(Guid id, ProjectAddMembersRequest request)
        {
            var command = _mapper.Map<AddMembersCommand>(request);
            command = command with { Id = id };

            var result = await _mediator.Send(command);

            return result.Match(
                addMembersResult => addMembersResult ? Ok() : BadRequest(),
                Problem);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProjectCommand(id);

            ErrorOr<bool> deleteResult = await _mediator.Send(command);

            return deleteResult.Match(
                deleteProjectResult => deleteProjectResult ? NoContent() : BadRequest(),
                Problem);
        }
    }
}
