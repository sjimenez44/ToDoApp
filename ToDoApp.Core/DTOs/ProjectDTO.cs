namespace ToDoApp.Core.DTOs
{
    using System.Collections.Generic;
    using ToDoApp.Core.Interfaces.DTOs;

    public class ProjectDTO : IProject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public List<TaskDTO> Tasks { get; set; }

        public override string ToString()
        {
            return $"[{Id}] :: {Name} - {Color} | No.Tasks: {Tasks.Count}";
        }
    }
}
