using ErrorOr;
using Template.ServiceErrors;
using Template.Models;

namespace Template.Services.Items
{
    public class ItemsService : IItemsService
    {
        private static readonly Dictionary<Guid, Item> _items = new();

        public ErrorOr<Created> CreateItem(Item item)
        {
            // TODO save in a database of choice
            _items.Add(item.Id, item);
            return Result.Created;
        }

        public ErrorOr<Item> GetItem(Guid id)
        {
            // TODO retrive from database of choice
            if (_items.TryGetValue(id, out var item))
            {
                return item;
            }

            return Errors.Item.NotFound;
        }

        public ErrorOr<Updated> UpdateItem(Item item)
        {
            // TODO update on database of choice
            // NOTE: This is actually 'upserting' for now
            _items[item.Id] = item;

            return Result.Updated;
        }

        public ErrorOr<Deleted> DeleteItem(Guid id)
        {
            // TODO delete/flag as deleted on database of choice
            _items.Remove(id);
            return Result.Deleted;
        }
    }
}
