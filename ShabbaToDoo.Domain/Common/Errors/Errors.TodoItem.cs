using ErrorOr;

namespace ShabbaToDoo.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Todo
        {
            public static Error NotFound => Error.NotFound(
                code: "Todo.NotFound",
                description: "Todo not found.");
        }
    }
}
