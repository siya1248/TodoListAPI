using Microsoft.EntityFrameworkCore;
using TodoList.Models;
namespace TodoList.API.Data;

public class TodoListContext : DbContext
{
    public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
    {

    }
    public DbSet<ToDoItem> ToDoItems {get; set;}

}
