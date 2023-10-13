using Microsoft.AspNetCore.Mvc;
using troiServer.models;

namespace troiServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ItemController:ControllerBase
{
    private readonly List<Item> items = new List<Item>
    {
        new Item{Id = 1,Name = "Tamani"},
        new Item{Id=2,Name = "Dcan"}
    };
    
    // GET: api/Items
    [HttpGet]
    public ActionResult<IEnumerable<Item>> Get()
    {
        return items;
    }
    
    // GET: api/Items/1
    [HttpGet("{id}")]
    public ActionResult<Item> Get(int id)
    {
        var item = items.FirstOrDefault(t => t.Id == id);
        if (items == null)
        {
            return NotFound();
        }

        return item;
    }

    [HttpPost]
    public IActionResult Post(Item item)
    {
        item.Id = items.Count + 1;
        items.Add(item);
        return CreatedAtAction("Get", new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Item updatedItem)
    {
        var existingItem = items.FirstOrDefault(t => t.Id == id);
        if (existingItem == null)
        {
            return NotFound();
        }

        existingItem.Name = updatedItem.Name;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        
        var todo = items.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        
        items.Remove(todo);
        return NoContent();
        }
    }

