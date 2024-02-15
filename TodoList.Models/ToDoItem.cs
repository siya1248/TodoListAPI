using System;
namespace TodoList.Models;
public class ToDoItem
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string? Description { get; set; }
    

        
        public ToDoItem(int id, DateTime dueDate, DateTime? completedDate, string description)
        {
            Id = id;
            DueDate = dueDate;
            CompletedDate = completedDate;
            Description = description;
        }
    

    }