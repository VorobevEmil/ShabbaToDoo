using ErrorOr;

namespace ShabbaToDoo.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "Auth.InvalidCred", 
                description: "Invalid Credentials.");

            public static Error FailedRegister => Error.Failure(
                code: "User.FailedRegister",
                description: "Failed to register, try again later");
        }
    }
}
