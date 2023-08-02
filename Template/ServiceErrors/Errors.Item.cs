using ErrorOr;

namespace Template.ServiceErrors
{
    public class Errors
    {
        public static class Item
        {
            public static Error NotFound => Error.NotFound(
                code: "Item.NotFound",
                description: "Item not found"
            );

            public static Error InvalidName => Error.Validation(
                code: "Item.InvalidName",
                description: $"Item name must be between {Models.Item.MinNameLength} and {Models.Item.MaxNameLength} characters long"
            );
        }
    }
}
