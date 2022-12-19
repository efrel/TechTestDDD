using ErrorOr;

namespace TechTestDDD.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email ya se encuentra en uso.");
        }
    }
}
