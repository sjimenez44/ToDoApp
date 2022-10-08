namespace ToDoApp.Core.DTOs
{
    using System;
    using ToDoApp.Core.Interfaces.DTOs;

    public class TaskDTO : ITask
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int Status { get; set; }

        public override string ToString()
        {
            return $"[{Id}] :: {Name} - {Created} | Status: {Status == 1}";
        }
    }
}
