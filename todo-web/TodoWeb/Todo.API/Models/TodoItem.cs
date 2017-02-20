using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo.API.Models
{
    public class TodoItem
    {
        public string Id { get; set; } 
        public string Name { get; set; }   
        public bool isComplete { get; set; } 

    }
}