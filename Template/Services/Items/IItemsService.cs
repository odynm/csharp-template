using ErrorOr;
using Template.Models;

namespace Template.Services.Items
{
    public interface IItemsService
    {
        ErrorOr<Created> CreateItem(Item item);
        ErrorOr<Item> GetItem(Guid id);
        ErrorOr<Updated> UpdateItem(Item item);
        ErrorOr<Deleted> DeleteItem(Guid id);
    }
}
