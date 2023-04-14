using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShabbaToDoo.Application.CQRS.Authentication.Commands.Register;
using ShabbaToDoo.Application.CQRS.Authentication.Common;
using ShabbaToDoo.Application.CQRS.Authentication.Queries.Login;
using ShabbaToDoo.Contracts.Authentication;

namespace ShabbaToDoo.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);


            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                userAuthResult => Ok(_mapper.Map<AuthenticationResponse>(userAuthResult)),
                Problem
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            var authResult = await _mediator.Send(query);

            return authResult.Match(
                userAuthResult => Ok(_mapper.Map<AuthenticationResponse>(userAuthResult)),
                Problem);
        }
    }
}