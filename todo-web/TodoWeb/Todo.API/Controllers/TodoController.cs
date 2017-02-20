using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Todo.API.Models;

namespace Todo.API.Controllers
{
    public class TodoController : ApiController
    {
        // GET api/<controller>
        static readonly ITodoRepository _databasePlaceHolder = new TodoRepository();
        
        public IEnumerable<TodoItem> Get()
        {
            return _databasePlaceHolder.GetAll();
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(string id)
        {
            
            var _item = _databasePlaceHolder.Find(id);
            if(_item == null)
            {
                var message = string.Format("todo with id = {0} not found", id);
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // POST api/<controller>
        public HttpResponseMessage Post(TodoItem item)
        {
            TodoItem _todo = new TodoItem { Name = item.Name };
            _databasePlaceHolder.Add(_todo);
            return Request.CreateResponse<TodoItem>(HttpStatusCode.Created, _todo);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(TodoItem item)
        {
            if(item == null)
            {
                var message = string.Format("todo with id = {0} not found");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            _databasePlaceHolder.Update(item);
            HttpResponseMessage response = Request.CreateResponse<TodoItem>(HttpStatusCode.OK, item);
            return response;
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(string id)
        {
            TodoItem item = _databasePlaceHolder.Find(id);
            if (item == null)
            {
                var message = string.Format("todo with id = {0} not found", id);
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            _databasePlaceHolder.Remove(id);
            HttpResponseMessage response = Request.CreateResponse<TodoItem>(HttpStatusCode.OK, item);
            return response;
        }
    }
}