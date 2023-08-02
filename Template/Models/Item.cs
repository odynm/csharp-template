using ErrorOr;
using Template.ServiceErrors;

namespace Template.Models
{
    public class Item
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 50;

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime DueDate { get; }
        public DateTime LastModified { get; }
        public List<string> SubItems { get; }

        private Item(
            Guid id,
            string name,
            string description,
            DateTime dueDate,
            DateTime lastModified,
            List<string> subItems)
        {
            Id = id;
            Name = name;
            Description = description;
            DueDate = dueDate;
            LastModified = lastModified;
            SubItems = subItems;
        }

        public static ErrorOr<Item> Create(
            string name,
            string description,
            DateTime dueDate,
            List<string> subItems,
            Guid? id = null)
        {
            List<Error> errors = new();

            if (name.Length is < MinNameLength or > MaxNameLength)
            {
                errors.Add(Errors.Item.InvalidName);
            }

            if (errors.Any())
            {
                return errors;
            }

            return new Item(
                id ?? Guid.NewGuid(),
                name,
                description,
                dueDate,
                DateTime.UtcNow,
                subItems
            );
        }
    }
}
