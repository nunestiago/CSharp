using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories
{


  public class InMemItemsRepo : IItemsRepo
  {
    private readonly List<Item> items = new()
    {
      new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 10, CreatedAt = DateTime.UtcNow },
      new Item { Id = Guid.NewGuid(), Name = "Hero", Price = 21, CreatedAt = DateTime.UtcNow },
      new Item { Id = Guid.NewGuid(), Name = "Monster", Price = 32, CreatedAt = DateTime.UtcNow },
    };

    public async Task<IEnumerable<Item>> GetItems()
    {
      return await Task.FromResult(items);
    }

    public async Task<Item> GetItem(Guid id)
    {
      var item = items.Where(item => item.Id == id).SingleOrDefault();
      return await Task.FromResult(item);
    }

    public async Task CreateItem(Item item)
    {
      items.Add(item);
      await Task.CompletedTask;
    }

    public async Task UpdateItem(Item item)
    {
      var index = items.FindIndex(i => i.Id == item.Id);
      items[index] = item;
      await Task.CompletedTask;
    }

    public async Task DeleteItem(Guid id)
    {
      var index = items.FindIndex(i => i.Id == id);
      items.RemoveAt(index);
      await Task.CompletedTask;

    }

    public Task<Item> GetItemAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<Item> GetItemsAsync()
    {
      throw new NotImplementedException();
    }

    public Task CreateItemAsync(Item item)
    {
      throw new NotImplementedException();
    }

    public Task UpdateItemAsync(Item item)
    {
      throw new NotImplementedException();
    }

    public Task DeleteItemAsync(Guid id)
    {
      throw new NotImplementedException();
    }
  }
}