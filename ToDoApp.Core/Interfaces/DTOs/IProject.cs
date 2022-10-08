namespace ToDoApp.Core.Interfaces.DTOs
{
    using System.Collections.Generic;
    using ToDoApp.Core.DTOs;

    public interface IProject
    {
        string Id { get; set; }
        string Name { get; set; }
        string Color { get; set; }
        List<TaskDTO> Tasks { get; set; }
    }
}
