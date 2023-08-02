using Microsoft.AspNetCore.Mvc;
using Template.Contracts.Item;
using Template.Models;
using Template.Services.Items;

namespace Template.Controllers
{
    public class ItemController : ApiController
    {
        private readonly IItemsService _itemService;

        public ItemController(IItemsService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public IActionResult CreateItem(CreateItemRequest request)
        {
            var requestToResult = Item.Create(
                request.Name,
                request.Description,
                request.DueDate,
                request.SubItems
            );

            if (requestToResult.IsError)
            {
                return Problem(requestToResult.Errors);
            }

            var item = requestToResult.Value;
            var result = _itemService.CreateItem(item);

            return result.Match(
                created => CreatedAtAction(
                    nameof(GetItem),
                    new { id = item.Id },
                    MapItemResponse(item)
                ),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetItem(Guid id)
        {
            var result = _itemService.GetItem(id);

            return result.Match(
                item => Ok(MapItemResponse(item)),
                errors => Problem(errors)
            );
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateItem(Guid id, UpdateItemRequest request)
        {
            var requestToResult = Item.Create(
                request.Name,
                request.Description,
                request.DueDate,
                request.SubItems,
                id
            );

            if (requestToResult.IsError)
            {
                return Problem(requestToResult.Errors);
            }

            var item = requestToResult.Value;

            _itemService.UpdateItem(item);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteItem(Guid id)
        {
            var result = _itemService.DeleteItem(id);

            return result.Match(
                deleted => NoContent(),
                errors => Problem(errors)
            );
        }

        private static ItemResponse MapItemResponse(Item item)
        {
            return new ItemResponse(
                            item.Id,
                            item.Name,
                            item.Description,
                            item.DueDate,
                            item.LastModified,
                            item.SubItems
                        );
        }
    }
}
