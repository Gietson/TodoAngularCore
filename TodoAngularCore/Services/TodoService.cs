using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAngularCore.Models;

namespace TodoAngularCore.Services
{
    public class TodoService : ITodoService
    {
        private static ISet<Todo> _tasks = new HashSet<Todo>()
                        {
                            new Todo("Sprzątanie"),
                            new Todo("Mycie"),
                            new Todo("Zamykwanie")
                        };

        public async Task<bool> AddAsync(Todo todo)
        {
            return await Task.FromResult(_tasks.Add(todo));
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
          => await Task.FromResult(_tasks);

        public async Task<Todo> GetAsync(Guid id)
          => await Task.FromResult(_tasks.SingleOrDefault(x => x.Id == id));

        public async Task<bool> RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            return _tasks.Remove(user);
        }

        //public async Task UpdateAsync(Todo todo)
        //{
        //    Todo t = _tasks.Single(x => x.Id == todo.Id);
        //    t.Message = todo.Message;
        //    t.Complete = todo.Complete;

        //}
    }
}
