using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
  [ApiController]
  [Route("items")]
  public class ItemsController : ControllerBase
  {
    private readonly IItemsRepo repository;
    public ItemsController(IItemsRepo repository)
    {
      this.repository = repository;
    }

    // GET /items
    [HttpGet]
    public async Task<IEnumerable<ItemDto>> GetItemsAsync()
    {
      var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());
      return items;
    }

    // GET /items/{id}
    [HttpGet("{id}")]
    public ActionResult<ItemDto> GetItem(Guid id)
    {
      var item = repository.GetItem(id);

      if (item is null)
        return NotFound();

      return item.AsDto();
    }

    // POST /items
    public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
    {
      Item item = new()
      {
        Id = Guid.NewGuid(),
        Name = itemDto.Name,
        Price = itemDto.Price,
        CreatedAt = DateTimeOffset.UtcNow
      };
      repository.CreateItem(item);

      return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
    }

    // PUT /items/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
    {
      Item item = repository.GetItem(id);

      if (item is null)
        return NotFound();


      Item updatedItem = item with
      {
        Name = itemDto.Name,
        Price = itemDto.Price
      };

      repository.UpdateItem(updatedItem);

      return NoContent();
    }

    // DELETE /items/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteItem(Guid id)
    {
      Item item = repository.GetItem(id);

      if (item is null)
        return NotFound();

      repository.DeleteItem(id);

      return NoContent();
    }
  }
}
