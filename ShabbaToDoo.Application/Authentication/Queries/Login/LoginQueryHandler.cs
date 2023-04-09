using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShabbaToDoo.Application.Common.Interfaces.Authentication;
using ShabbaToDoo.Domain.Entities;
using ShabbaToDoo.Domain.Common.Errors;
using ShabbaToDoo.Application.Authentication.Common;

namespace ShabbaToDoo.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, UserManager<ApplicationUser> userManager)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (await _userManager.FindByEmailAsync(query.Email) is not ApplicationUser user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (!await _userManager.CheckPasswordAsync(user, query.Password))
            {
                return Errors.Authentication.InvalidCredentials;

            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
