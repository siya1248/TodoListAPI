using System;
using TodoList.Models;
using Xunit;
namespace TodoList.Tests;

public class TodoListTest
{
    [Fact]
    public void CreateNewToDoItem()
        {
            
            var dueDate = DateTime.Now.AddDays(1);
            var description = "Buy groceries";

            
            var todoItem = new ToDoItem(1, dueDate, null, description);

            
            Assert.Equal(1, todoItem.Id);
            Assert.Equal(dueDate, todoItem.DueDate);
            Assert.Null(todoItem.CompletedDate);
            Assert.Equal(description, todoItem.Description);
        }
        [Fact]
        public void ToDoItemAsCompleted()
        {
            
            var dueDate = DateTime.Now.AddDays(1);
            var description = "Buy groceries";
            var todoItem = new ToDoItem(1, dueDate, null, description);
            var completedDate = DateTime.Now;
           
            todoItem.CompletedDate = completedDate;

            
            Assert.NotNull(todoItem.CompletedDate);
            Assert.Equal(DateTime.Today, todoItem.CompletedDate?.Date);
        }

        [Fact]
        public void ToDoItemCompare()
        {
            
            var dueDate1 = DateTime.Now.AddDays(1);
            var dueDate2 = DateTime.Now.AddDays(2);
            var description = "Buy groceries";
            var todoItem1 = new ToDoItem(1, dueDate1, null, description);
            var todoItem2 = new ToDoItem(2, dueDate2, null, description);

            
            var result = todoItem1.DueDate.CompareTo(todoItem2.DueDate);

            
            Assert.True(result > 0);
        }

        [Fact]
        public void ToDoItemDoesNotComplete()
        {
            
            var dueDate = DateTime.Now.AddDays(1);
            var description = "Buy groceries";
            var todoItem = new ToDoItem(1, dueDate, null, description);
            var initialCompletedDate = todoItem.CompletedDate;
            
            todoItem.CompletedDate = null;

           
            Assert.Equal(initialCompletedDate, todoItem.CompletedDate);
        }
}