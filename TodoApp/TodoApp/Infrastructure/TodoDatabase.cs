using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace TodoApp.Infrastructure
{
    public class TodoDatabase
    {
        private SQLiteConnection database;
        private static object _lock = new object();
    }
    
    public TodoDatabase()
    {
        database = DependencyService.Get<ISQLite>().GetConnection();
        database.CreateTable<TodoItem>();
    }

    public int Save(TodoItem todoItem)
    {
        lock (_lock)
        {
            if (todoItem.Id != 0)
            {
                database.Update(todoItem);
            }
            else
            {
                database.Insert(todoItem);
            }
            return todoItem.Id;
        }
    }

    public TodoItem GetTodo(int id)
    {
        lock (_lock)
        {
            return database.Table<TodoItem>()
                .FirstOrDefault(t => t.id == id);
            
        }
    }

    public IList<TodoItem> GetTodos()
    {
        lock (_lock)
        {
            return database.Table<TodoItem>().ToList();
        }
    }
}
