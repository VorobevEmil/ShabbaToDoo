using System.Security.Claims;

namespace ShabbaToDoo.Application.Common.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal identity)
        {
            var userIdClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new ApplicationException("Failed to get user id from ClaimsPrincipal.");
            }
            return userIdClaim.Value;
        }
    }
}
