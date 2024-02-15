using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoList.API.Data;
using TodoList.Models;

namespace TodoList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoItemsController : ControllerBase
    {
        private readonly DataContext _context;

        public ToDoItemsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("incomplete")]
        public ActionResult<IEnumerable<ToDoItem>> GetIncompleteToDoItems()
        {
            var incompleteItems = _context.ToDoItems.Where(item => item.CompletedDate == null).ToList();
            return Ok(incompleteItems);
        }

        [HttpGet("{id}")]
        public ActionResult<ToDoItem> GetToDoItem(int id)
        {
            var item = _context.ToDoItems.FirstOrDefault(item => item.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<ToDoItem> AddToDoItem(ToDoItem newItem)
        {
            _context.ToDoItems.Add(newItem);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetToDoItem), new { id = newItem.Id }, newItem);
        }

        [HttpPost("{id}/complete")]
        public ActionResult<ToDoItem> CompleteToDoItem(int id)
        {
            var item = _context.ToDoItems.FirstOrDefault(item => item.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            if(item.CompletedDate == null)
            {
             //item.CompletedDate = DateTime.Now;
            _context.SaveChanges();
            }

            return Ok(item);
        }



    }
}
