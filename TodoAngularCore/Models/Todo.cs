using System;

namespace TodoAngularCore.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public bool Complete { get; set; }

        public Todo(string message)
        {
          Id = Guid.NewGuid();
          Message = message;
          Complete = false;
         // CreateAt = DateTime.Now;
        }
    }


}
