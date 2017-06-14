using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAngularCore.Models;

namespace TodoAngularCore.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo> GetAsync(Guid id);
        Task<bool> AddAsync(Todo todo);
        Task UpdateAsync(Todo todo);
        Task<bool> RemoveAsync(Guid id);
    }
}
