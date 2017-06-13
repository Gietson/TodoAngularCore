using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAngularCore.Models;
using TodoAngularCore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAngularCore.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Todo>> GetAsync()
        {
            return await _todoService.GetAllAsync();
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public async Task<Todo> Get(Guid? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        throw new ArgumentException($"[Get] Błędny guid id='{id}'");
        //    }
        //    return await _todoService.GetAsync(id.Value);
        //}

        // POST api/values
        [HttpPost]
        public async Task<bool> Post([FromBody]Todo todo)
        {
            return await _todoService.AddAsync(todo);
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public async Task Put(int id, [FromBody]string value)
        //{
        //    await _todoService.UpdateAsync(new Todo(value));
        //}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentException($"[Get] Błędny guid id='{id}'");
            }
            return await _todoService.RemoveAsync(id.Value);
        }
    }
}
