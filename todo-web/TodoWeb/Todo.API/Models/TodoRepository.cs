using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Web;

namespace Todo.API.Models
{
    public class TodoRepository : ITodoRepository
    {
        private List<TodoItem> _todos = new List<TodoItem>();
        public TodoRepository()
        {
            this.Add(new TodoItem { Id = Guid.NewGuid().ToString(), Name = "todo 1", isComplete = false });
            this.Add(new TodoItem { Id = Guid.NewGuid().ToString(), Name = "todo 2", isComplete = false });
            this.Add(new TodoItem { Id = Guid.NewGuid().ToString(), Name = "todo 3", isComplete = false });

        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todos;
        }
        public void Add(TodoItem item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("Empty Object");
            }
            item.Id = Guid.NewGuid().ToString();
            item.isComplete = false;
            _todos.Add(item);            
        }

        public void Update(TodoItem item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("Empty Object");
            }
            int index = _todos.FindIndex(p => p.Id == item.Id);
            if(index == -1)
            {
                throw new Exception("No matching todo");
            }
            _todos.RemoveAt(index);
            _todos.Add(item);
        }

        public TodoItem Remove(string key)
        {
            TodoItem item;
            item = _todos.Find(p => p.Id == key);
            int index = _todos.FindIndex(p => p.Id == key);
            if(index == -1)
            {
                throw new Exception("No matching todo to remove");
            }
            _todos.RemoveAt(index);
            return item;

        }

        public TodoItem Find(string key)
        {
            return _todos.Find(p => p.Id == key);
        }
    }
}