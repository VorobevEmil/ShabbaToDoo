using ErrorOr;
using MediatR;
using ShabbaToDoo.Application.Common.Interfaces.Authentication;
using ShabbaToDoo.Domain.Entities;
using ShabbaToDoo.Domain.Common.Errors;
using Microsoft.AspNetCore.Identity;
using ShabbaToDoo.Application.CQRS.Authentication.Common;

namespace ShabbaToDoo.Application.CQRS.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, UserManager<ApplicationUser> userManager)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (await _userManager.FindByEmailAsync(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var user = new ApplicationUser()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                UserName = command.UserName,
                Email = command.Email,
            };

            var result = await _userManager.CreateAsync(user, command.Password);
            if (result.Succeeded)
            {
                var token = _jwtTokenGenerator.GenerateToken(user);
                return new AuthenticationResult(user, token);
            }

            return Errors.Authentication.FailedRegister;
        }
    }
}
