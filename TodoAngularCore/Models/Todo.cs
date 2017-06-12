using System;

namespace TodoAngularCore.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public bool Complete { get; set; }
    }
}
